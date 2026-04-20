<?php
header("Content-Type: application/json");
$host = "sql213.hstn.me";
$dbname = "mseet_41306550_komodohubDB";
$username_db = "mseet_41306550";
$password_db = "zXTvI8lYfPGc";

$conn = new mysqli($host, $username_db, $password_db, $dbname);
if ($conn->connect_error) { echo json_encode([]); exit(); }

$submission_id = isset($_GET['submission_id']) ? $conn->real_escape_string($_GET['submission_id']) : '';
if (empty($submission_id)) { echo json_encode([]); exit(); }

$sql = "SELECT teacher_id, note_text, created_at 
        FROM Teacher_Note 
        WHERE submission_id = '$submission_id'
        ORDER BY created_at ASC";

$result = $conn->query($sql);
$notes = [];
if ($result) {
    while ($row = $result->fetch_assoc()) {
        $notes[] = $row;
    }
}
echo json_encode($notes);
$conn->close();
?>