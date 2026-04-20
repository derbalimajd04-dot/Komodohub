<?php
header("Content-Type: application/json");

$host = "sql213.hstn.me";
$dbname = "mseet_41306550_komodohubDB";
$username_db = "mseet_41306550";
$password_db = "zXTvI8lYfPGc";
$conn = new mysqli($host, $username_db, $password_db, $dbname);
if ($conn->connect_error) {
    echo json_encode([]);
    exit();
}
$sql = "SELECT id, username, title, report_text, image_path, created_at 
        FROM Submissions 
        ORDER BY created_at DESC";
$result = $conn->query($sql);
$submissions = [];
if ($result) {
    while ($row = $result->fetch_assoc()) {
        $submissions[] = $row;
    }
}
echo json_encode($submissions);
$conn->close();
?>