<?php

error_reporting(E_ALL);
ini_set('display_errors', 1);

$config = parse_ini_file("config.ini");

$conn = new mysqli(
    $config['db_host'],
    $config['db_user'],
    $config['db_pass'],
    $config['db_name']
);

if ($conn->connect_error) {
    die("DB_ERROR");
}

if (!isset($_GET['name'], $_GET['password'], $_GET['school_id'], $_GET['codename'])) {
    die("MISSING_FIELDS");
}

$name = trim($_GET['name']);
$password = $_GET['password'];
$school_id = (int)$_GET['school_id'];
$codename = trim($_GET['codename']);
$days = isset($_GET['days']) ? (int)$_GET['days'] : 7;

if ($name === "" || $password === "" || $codename === "" || $school_id <= 0) {
    die("EMPTY_FIELDS");
}

if ($days < 1) {
    $days = 7;
}

/*
1. Authenticate teacher
*/
$sql = "SELECT user_id, role, password_hash
        FROM users
        WHERE name = ?
        LIMIT 1";

$stmt = $conn->prepare($sql);

if (!$stmt) {
    die("PREPARE_FAILED: " . $conn->error);
}

$stmt->bind_param("s", $name);

if (!$stmt->execute()) {
    die("EXECUTE_FAILED: " . $stmt->error);
}

$stmt->store_result();

if ($stmt->num_rows === 0) {
    $stmt->close();
    $conn->close();
    die("LOGIN_FAILED");
}

$stmt->bind_result($user_id, $role, $password_hash);
$stmt->fetch();
$stmt->close();

/*
2. Verify password
*/
if (!password_verify($password, $password_hash)) {
    $conn->close();
    die("LOGIN_FAILED");
}

/*
3. Check teacher role
*/
if (strtoupper(trim($role)) !== "TEACHER") {
    $conn->close();
    die("NOT_TEACHER");
}

/*
4. Prevent duplicate code
*/
$checkSql = "SELECT code_id FROM Access_Code WHERE code = ? LIMIT 1";
$checkStmt = $conn->prepare($checkSql);

if (!$checkStmt) {
    $conn->close();
    die("PREPARE_FAILED: " . $conn->error);
}

$checkStmt->bind_param("s", $codename);

if (!$checkStmt->execute()) {
    $checkStmt->close();
    $conn->close();
    die("EXECUTE_FAILED: " . $checkStmt->error);
}

$checkStmt->store_result();

if ($checkStmt->num_rows > 0) {
    $checkStmt->close();
    $conn->close();
    die("CODE_ALREADY_EXISTS");
}

$checkStmt->close();

/*
5. Insert code
*/
$expires_at = date("Y-m-d H:i:s", strtotime("+$days days"));
$status = "ACTIVE";

$insertSql = "INSERT INTO Access_Code (school_id, code, created_by, expires_at, status)
              VALUES (?, ?, ?, ?, ?)";

$insertStmt = $conn->prepare($insertSql);

if (!$insertStmt) {
    $conn->close();
    die("PREPARE_FAILED: " . $conn->error);
}

$insertStmt->bind_param("isiss", $school_id, $codename, $user_id, $expires_at, $status);

if ($insertStmt->execute()) {
    echo "CODE_CREATED|" . $codename . "|" . $school_id . "|" . $expires_at;
} else {
    echo "CODE_CREATE_FAILED|" . $insertStmt->error;
}

$insertStmt->close();
$conn->close();
?>