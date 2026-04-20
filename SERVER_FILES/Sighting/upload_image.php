<?php
error_reporting(E_ALL);
ini_set('display_errors', 1);

$image_data = isset($_GET['image_data']) ? $_GET['image_data'] : '';
$filename = isset($_GET['filename']) ? $_GET['filename'] : '';

if (empty($image_data) || empty($filename)) {
    echo "NO_DATA";
    exit;
}

$target_dir = "uploads/";
if (!is_dir($target_dir)) {
    mkdir($target_dir, 0777, true);
}

$decoded = base64_decode($image_data);
$target_file = $target_dir . time() . "_" . $filename;

if (file_put_contents($target_file, $decoded)) {
    echo "UPLOAD_OK|" . $target_file;
} else {
    echo "UPLOAD_FAILED";
}
?>