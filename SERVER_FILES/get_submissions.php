<?php
header("Content-Type: application/json");

$host = "sql213.hstn.me";
$dbname = "mseet_41306550_komodohubDB";
$username = "mseet_41306550";
$password = "zXTvI8lYfPGc";
$conn = new mysqli($host, $username, $password, $dbname);

if ($conn->connect_error) {
    echo json_encode(["success" => false, "message" => "Database connection failed"]);
    exit();
}

// We completely ignore ?username= and just return ALL submissions
$sql = "SELECT id, username, title, report_text, image_path, created_at
        FROM Submissions
        ORDER BY id DESC";

$result = $conn->query($sql);

if (!$result) {
    echo json_encode(["success" => false, "message" => "Query failed", "error" => $conn->error]);
    exit();
}

$submissions = [];

while ($row = $result->fetch_assoc()) {
    $submissions[] = $row;
}

echo json_encode($submissions);

$conn->close();
?>