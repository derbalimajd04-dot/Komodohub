<?php
ini_set('display_errors', 1);
error_reporting(E_ALL);

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

$name     = $_GET['name']     ?? '';
$email    = $_GET['email']    ?? '';
$password = $_GET['password'] ?? '';
$role     = isset($_GET['role']) ? strtoupper($_GET['role']) : "STUDENT";

// Only allow valid roles
$allowedRoles = ['STUDENT', 'TEACHER', 'ADMIN'];
if (!in_array($role, $allowedRoles)) {
    echo "INVALID_ROLE";
    exit;
}

if (empty($name) || empty($email) || empty($password)) {
    echo "MISSING_FIELDS";
    exit;
}

// Check for duplicate email or username
$check = $conn->prepare("SELECT user_id FROM users WHERE name = ? OR email = ?");
$check->bind_param("ss", $name, $email);
$check->execute();
$check->store_result();

if ($check->num_rows > 0) {
    echo "ALREADY_EXISTS";
    exit;
}

$school_id     = 1;
$password_hash = password_hash($password, PASSWORD_DEFAULT);
$avatar_theme  = "default";

$sql = "INSERT INTO users (school_id, role, name, email, password_hash, avatar_theme, created_at)
        VALUES (?, ?, ?, ?, ?, ?, NOW())";

$stmt = $conn->prepare($sql);
$stmt->bind_param("isssss", $school_id, $role, $name, $email, $password_hash, $avatar_theme);

if ($stmt->execute()) {
    echo "REGISTER_SUCCESS";
} else {
    echo "REGISTER_FAILED";
}
?>