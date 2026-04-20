<?php
$host = "sql213.hstn.me";
$dbname = "mseet_41306550_komodohubDB";
$username_db = "mseet_41306550";
$password_db = "zXTvI8lYfPGc";

$conn = new mysqli($host, $username_db, $password_db, $dbname);

if ($conn->connect_error) {
    echo "DB_CONNECTION_ERROR";
    exit();
}

$username    = isset($_GET['username'])    ? $conn->real_escape_string($_GET['username'])    : '';
$activity_id = isset($_GET['activity_id']) ? $conn->real_escape_string($_GET['activity_id']) : '';
$title       = isset($_GET['title'])       ? $conn->real_escape_string($_GET['title'])       : '';
$report_text = isset($_GET['report_text']) ? $conn->real_escape_string($_GET['report_text']) : '';

if (empty($username) || empty($activity_id) || empty($title) || empty($report_text)) {
    echo "MISSING_FIELDS";
    exit();
}

$sql = "INSERT INTO Submissions (username, title, report_text, created_at) 
        VALUES ('$username', '$title', '$report_text', NOW())";

if ($conn->query($sql)) {
    echo "SUBMISSION_SUCCESS";
} else {
    echo "DB_ERROR:" . $conn->error;
}

$conn->close();
?>