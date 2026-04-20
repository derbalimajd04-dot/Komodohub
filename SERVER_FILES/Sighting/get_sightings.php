<?php
header('Content-Type: application/json');

$conn = new mysqli("sql213.hstn.me", "mseet_41306550", "zXTvI8lYfPGc", "mseet_41306550_komodohubDB");
if ($conn->connect_error) { echo "[]"; exit; }

$username = isset($_GET['username']) ? $_GET['username'] : '';

if (!empty($username)) {
    $stmt = $conn->prepare("SELECT * FROM sighting_report WHERE username = ? ORDER BY created_at DESC");
    $stmt->bind_param("s", $username);
} else {
    $stmt = $conn->prepare("SELECT * FROM sighting_report ORDER BY created_at DESC");
}

$stmt->execute();
$result = $stmt->get_result();
$sightings = [];

while ($row = $result->fetch_assoc()) {
    $sightings[] = $row;
}

echo json_encode($sightings);
$stmt->close();
$conn->close();
?>