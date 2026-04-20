<?php
$host = "sql213.hstn.me";
$dbname = "mseet_41306550_komodohubDB";
$username_db = "mseet_41306550";
$password_db = "zXTvI8lYfPGc";

$conn = new mysqli($host, $username_db, $password_db, $dbname);
if ($conn->connect_error) { echo "DB_ERROR"; exit(); }

$username    = isset($_GET['username'])    ? $conn->real_escape_string($_GET['username'])    : '';
$program_id  = isset($_GET['program_id'])  ? $conn->real_escape_string($_GET['program_id'])  : '';
$access_code = isset($_GET['access_code']) ? $conn->real_escape_string($_GET['access_code']) : '';

if (empty($username) || empty($program_id) || empty($access_code)) {
    echo "MISSING_FIELDS";
    exit();
}

// Validate access code
$codeCheck = $conn->prepare("SELECT code_id FROM Access_Code WHERE code = ? AND status = 'ACTIVE' AND expires_at > NOW()");
$codeCheck->bind_param("s", $access_code);
$codeCheck->execute();
$codeResult = $codeCheck->get_result();
if ($codeResult->num_rows === 0) {
    echo "INVALID_ACCESS_CODE";
    exit();
}

// Get user_id from username
$userQuery = $conn->prepare("SELECT user_id FROM users WHERE name = ?");
$userQuery->bind_param("s", $username);
$userQuery->execute();
$userResult = $userQuery->get_result();
if ($userResult->num_rows === 0) { echo "USER_NOT_FOUND"; exit(); }
$user = $userResult->fetch_assoc();
$user_id = $user['user_id'];

// Check not already enrolled
$check = $conn->prepare("SELECT enrolment_id FROM Enrolment WHERE user_id = ? AND program_id = ?");
$check->bind_param("ii", $user_id, $program_id);
$check->execute();
$check->store_result();
if ($check->num_rows > 0) { echo "ALREADY_ENROLLED"; exit(); }

// Enroll
$stmt = $conn->prepare("INSERT INTO Enrolment (user_id, program_id, enrolled_at) VALUES (?, ?, NOW())");
$stmt->bind_param("ii", $user_id, $program_id);
if ($stmt->execute()) {
    echo "ENROLL_SUCCESS";
} else {
    echo "DB_ERROR:" . $conn->error;
}
$conn->close();
?>