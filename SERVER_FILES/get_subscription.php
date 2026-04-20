<?php
header("Content-Type: application/json");
$host = "sql213.hstn.me";
$dbname = "mseet_41306550_komodohubDB";
$username_db = "mseet_41306550";
$password_db = "zXTvI8lYfPGc";

$conn = new mysqli($host, $username_db, $password_db, $dbname);
if ($conn->connect_error) { echo json_encode([]); exit(); }

$school_id = isset($_GET['school_id']) ? $conn->real_escape_string($_GET['school_id']) : '1';

$sql = "SELECT sub_id, school_id, plan, status, start_date, end_date 
        FROM Subscription 
        WHERE school_id = '$school_id'
        ORDER BY end_date DESC LIMIT 1";

$result = $conn->query($sql);
$sub = [];
if ($result && $result->num_rows > 0) {
    $sub = $result->fetch_assoc();
}
echo json_encode($sub);
$conn->close();
?>