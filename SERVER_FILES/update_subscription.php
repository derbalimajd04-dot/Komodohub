<?php
$host = "sql213.hstn.me";
$dbname = "mseet_41306550_komodohubDB";
$username_db = "mseet_41306550";
$password_db = "zXTvI8lYfPGc";

$conn = new mysqli($host, $username_db, $password_db, $dbname);
if ($conn->connect_error) { echo "DB_ERROR"; exit(); }

$school_id = isset($_GET['school_id']) ? $conn->real_escape_string($_GET['school_id']) : '';
$plan      = isset($_GET['plan'])      ? $conn->real_escape_string($_GET['plan'])      : '';
$status    = isset($_GET['status'])    ? $conn->real_escape_string($_GET['status'])    : '';
$end_date  = isset($_GET['end_date'])  ? $conn->real_escape_string($_GET['end_date'])  : '';

if (empty($school_id) || empty($plan) || empty($status) || empty($end_date)) {
    echo "MISSING_FIELDS";
    exit();
}

$check = $conn->query("SELECT sub_id FROM Subscription WHERE school_id = '$school_id'");
if ($check->num_rows > 0) {
    $sql = "UPDATE Subscription SET plan='$plan', status='$status', end_date='$end_date' 
            WHERE school_id='$school_id'";
} else {
    $sql = "INSERT INTO Subscription (school_id, plan, status, start_date, end_date) 
            VALUES ('$school_id', '$plan', '$status', NOW(), '$end_date')";
}

if ($conn->query($sql)) {
    echo "SUBSCRIPTION_UPDATED";
} else {
    echo "DB_ERROR:" . $conn->error;
}
$conn->close();
?>