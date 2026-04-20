<?php
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Headers: *");

// Our database connection details from the hosting platform
$host = "sql213.hstn.me";
$user = "mseet_41306550";
$password = "Komodohub12341";
$database = "mseet_41306550_komodohubDB";

$conn = new mysqli($host, $user, $password, $database);

// checking the connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}
