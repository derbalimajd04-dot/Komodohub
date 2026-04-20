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

$sql = "SELECT activity_id, title, description, activity_type, due_date, image_path FROM Activity ORDER BY created_at DESC";
$result = $conn->query($sql);

$activities = [];
while ($row = $result->fetch_assoc()) {
    $activities[] = $row;
}

echo json_encode($activities);
?>