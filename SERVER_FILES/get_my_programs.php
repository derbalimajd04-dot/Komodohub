<?php
header("Content-Type: application/json");
$host = "sql213.hstn.me";
$dbname = "mseet_41306550_komodohubDB";
$username_db = "mseet_41306550";
$password_db = "zXTvI8lYfPGc";

$conn = new mysqli($host, $username_db, $password_db, $dbname);
if ($conn->connect_error) { echo json_encode([]); exit(); }

$username = isset($_GET['username']) ? $conn->real_escape_string($_GET['username']) : '';
if (empty($username)) { echo json_encode([]); exit(); }

$sql = "SELECT p.program_id, p.title, p.description, p.organisation_type, e.enrolled_at
        FROM Enrolment e
        JOIN Program p ON e.program_id = p.program_id
        JOIN users u ON e.user_id = u.user_id
        WHERE u.name = '$username'
        ORDER BY e.enrolled_at DESC";

$result = $conn->query($sql);
$programs = [];
if ($result) {
    while ($row = $result->fetch_assoc()) {
        $programs[] = $row;
    }
}
echo json_encode($programs);
$conn->close();
?>