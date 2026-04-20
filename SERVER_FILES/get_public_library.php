<?php
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json");

// for our database connection
$host = "sql213.hstn.me";
$dbname = "mseet_41306550_komodohubDB";
$username_db = "mseet_41306550";
$password_db = "zXTvI8lYfPGc";

$conn = new mysqli($host, $username_db, $password_db, $dbname);
if ($conn->connect_error) {
    echo "DB_CONNECTION_ERROR: " . $conn->connect_error;
    exit();
}

$search   = isset($_GET['search']) ? trim($_GET['search']) : "";
$category = isset($_GET['category']) ? trim($_GET['category']) : "";
$sort     = isset($_GET['sort']) ? trim($_GET['sort']) : "newest";
$page     = isset($_GET['page']) ? (int)$_GET['page'] : 1;
$pageSize = isset($_GET['pageSize']) ? (int)$_GET['pageSize'] : 12;

if ($page < 1) $page = 1;
if ($pageSize < 1 || $pageSize > 50) $pageSize = 12;

$offset = ($page - 1) * $pageSize;

// to fetch all public submissions
$sql = "SELECT id, username, title, report_text, image_path, category, is_school 
        FROM Submissions 
        WHERE is_public = 1";
        
if ($search !== "") {
    $safe = $conn->real_escape_string($search);
    $sql .= " AND (title LIKE '%$safe%' OR report_text LIKE '%$safe%')";
}

if ($category !== "") {
    $safeCat = $conn->real_escape_string($category);
    $sql .= " AND category = '$safeCat'";
}

if ($sort === "oldest") {
    $sql .= " ORDER BY created_at ASC";
} else {
    $sql .= " ORDER BY created_at DESC";
}
$sql .= " LIMIT $pageSize OFFSET $offset";

$result = $conn->query($sql);
$rows = [];

while ($row = $result->fetch_assoc()) {
    // Hide student names for school submissions for their privacy
    if ($row["is_school"] == "1") {
        $row["username"] = "Student Contributor";
    }
    $rows[] = $row;
}

echo json_encode($rows);
$conn->close();
?><?php
