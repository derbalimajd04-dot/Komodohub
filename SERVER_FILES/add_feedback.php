<?php
error_reporting(E_ALL);
ini_set('display_errors', 1);

$host = "sql213.hstn.me";
$dbname = "mseet_41306550_komodohubDB";
$username_db = "mseet_41306550";
$password_db = "zXTvI8lYfPGc";

$conn = new mysqli($host, $username_db, $password_db, $dbname);
if ($conn->connect_error) {
    echo "DB_CONNECTION_ERROR: " . $conn->connect_error;
    exit();
}

$submission_id = isset($_GET['submission_id']) ? $conn->real_escape_string($_GET['submission_id']) : '';
$teacher_id    = isset($_GET['teacher_id'])    ? $conn->real_escape_string($_GET['teacher_id'])    : '';
$note_text     = isset($_GET['note_text'])     ? $conn->real_escape_string($_GET['note_text'])     : '';

if (empty($submission_id) || empty($teacher_id) || empty($note_text)) {
    echo "MISSING_FIELDS";
    exit();
}

$sql = "INSERT INTO Teacher_Note (submission_id, teacher_id, note_text, created_at) 
        VALUES ('$submission_id', '$teacher_id', '$note_text', NOW())";

if ($conn->query($sql)) {
    echo "FEEDBACK_SUCCESS";
} else {
    echo "DB_ERROR: " . $conn->error;
}

$conn->close();
?>