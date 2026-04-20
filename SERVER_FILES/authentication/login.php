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

// Accept GET because your C# sends credentials in the URL
if (!isset($_GET['name'], $_GET['password'])) {
    die("MISSING_FIELDS");
}

$name = trim($_GET['name']);
$password = $_GET['password'];

if ($name === "" || $password === "") {
    die("EMPTY_FIELDS");
}

$sql = "SELECT user_id, school_id, role, name, email, password_hash, avatar_theme
        FROM users
        WHERE name = ? AND is_active = 1
        LIMIT 1";

$stmt = $conn->prepare($sql);

if (!$stmt) {
    die("PREPARE_FAILED");
}

$stmt->bind_param("s", $name);

if (!$stmt->execute()) {
    die("EXECUTE_FAILED");
}

$stmt->store_result();

if ($stmt->num_rows === 0) {
    echo "LOGIN_FAILED";
    $stmt->close();
    $conn->close();
    exit;
}

$stmt->bind_result($user_id, $school_id, $role, $db_name, $email, $password_hash, $avatar_theme);
$stmt->fetch();

if (password_verify($password, $password_hash)) {
    echo "LOGIN_SUCCESS|"
        . $user_id . "|"
        . $school_id . "|"
        . $role . "|"
        . $db_name . "|"
        . $email . "|"
        . $avatar_theme;
} else {
    echo "LOGIN_FAILED";
}

$stmt->close();
$conn->close();
?>