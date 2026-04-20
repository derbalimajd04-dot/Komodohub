<?php
error_reporting(E_ALL);
ini_set('display_errors', 1);

$conn = new mysqli("sql213.hstn.me", "mseet_41306550", "zXTvI8lYfPGc", "mseet_41306550_komodohubDB");
if ($conn->connect_error) { die("DB_ERROR: " . $conn->connect_error); }

$username = isset($_GET['username']) ? $_GET['username'] : '';
$species = isset($_GET['species']) ? $_GET['species'] : '';
$location = isset($_GET['location']) ? $_GET['location'] : '';
$date = isset($_GET['sighting_date']) ? $_GET['sighting_date'] : '';
$description = isset($_GET['description']) ? $_GET['description'] : '';
$image_path = isset($_GET['image_path']) ? $_GET['image_path'] : '';

if (empty($username) || empty($species) || empty($location) || empty($date)) {
    die("MISSING_FIELDS");
}

$stmt = $conn->prepare("INSERT INTO sighting_report (username, species, location, sighting_date, description, image_path) VALUES (?, ?, ?, ?, ?, ?)");
if (!$stmt) { die("PREPARE_FAILED: " . $conn->error); }

$stmt->bind_param("ssssss", $username, $species, $location, $date, $description, $image_path);

if ($stmt->execute()) {
    echo "SIGHTING_SUBMITTED";
} else {
    echo "SUBMIT_FAILED: " . $stmt->error;
}

$stmt->close();
$conn->close();
?>