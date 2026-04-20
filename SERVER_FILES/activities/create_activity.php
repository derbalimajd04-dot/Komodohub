<?php
$config = parse_ini_file("../config.ini");
$conn = new mysqli(
    $config['db_host'],
    $config['db_user'],
    $config['db_pass'],
    $config['db_name']
);
if ($conn->connect_error) {
    die("DB_ERROR");
}

$title = $_GET['title'] ?? '';
$description = $_GET['description'] ?? '';
$activity_type = $_GET['activity_type'] ?? '';
$due_date = $_GET['due_date'] ?? '';
$program_id = $_GET['program_id'] ?? '1';
$image_path = $_GET['image_path'] ?? '';

if (empty($title) || empty($description) || empty($activity_type) || empty($due_date)) {
    die("MISSING_FIELDS");
}

$stmt = $conn->prepare("INSERT INTO Activity (program_id, title, description, activity_type, due_date, image_path) VALUES (?, ?, ?, ?, ?, ?)");
$stmt->bind_param("isssss", $program_id, $title, $description, $activity_type, $due_date, $image_path);

if ($stmt->execute()) {
    echo "ACTIVITY_CREATED";
} else {
    echo "ACTIVITY_FAILED";
}

$stmt->close();
$conn->close();
?>