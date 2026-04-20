<?php
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: POST, OPTIONS");

if (!isset($_FILES['image']) || $_FILES['image']['error'] !== UPLOAD_ERR_OK) {
    die("UPLOAD_ERROR");
}

$uploadDir = '../uploads/activities/';
if (!is_dir($uploadDir)) mkdir($uploadDir, 0777, true);

$ext = strtolower(pathinfo($_FILES['image']['name'], PATHINFO_EXTENSION));
$filename = uniqid('act_', true) . '.' . $ext;

if (move_uploaded_file($_FILES['image']['tmp_name'], $uploadDir . $filename)) {
    echo "http://komodoproject.zya.me/uploads/activities/" . $filename;
} else {
    die("SAVE_ERROR");
}
?>