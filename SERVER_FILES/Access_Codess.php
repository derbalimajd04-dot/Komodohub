<?php

// Our database connection details from the hosting platform
$host = "sql213.hstn.me";
$user = "mseet_41306550";
$password = "Komodohub12341";
$database = "mseet_41306550_komodohubDB";

// we have to connect to the database
$conn = new mysqli($host, $user, $password, $database);

if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

// Generate a secure random invitation code for the student
function generateCode($length = 10)
{
    $bytes = ceil($length / 2);
    $random = bin2hex(random_bytes($bytes));
    return strtoupper(substr($random, 0, $length));
}

$action = $_POST['action'] ?? '';

if ($action == "") {
    http_response_code(400);
    echo "Invalid request: action not provided.";
    exit();
}

if ($action == "generate") {

    $code = generateCode();

    // This generates the school_id
    $school_id = rand(1, 5);

 
    $created_by = 33;
    $expires_at = date("Y-m-d H:i:s", strtotime("+1 year"));
    $status = "ACTIVE";

    // now we insert the full row into our Access_Code table
    $stmt = $conn->prepare("
        INSERT INTO Access_Code (school_id, code, created_by, expires_at, status)
        VALUES (?, ?, ?, ?, ?)
    ");

    $stmt->bind_param("isiss", $school_id, $code, $created_by, $expires_at, $status);

    if ($stmt->execute()) {
        echo "Your code is: " . $code;
    } else {
        echo "Error";
    }

    $stmt->close();

} elseif ($action == "verify") {

    $code = $_POST['code'] ?? '';

    // verify the code format
    if ($code === '' || !preg_match('/^[A-Z0-9]{10}$/', $code)) {
        http_response_code(400);
        echo "Invalid code format.";
        exit();
    }

    // we will check if the code exists and if it is active
    $stmt = $conn->prepare("
        SELECT * FROM Access_Code 
        WHERE code=? AND status='ACTIVE'
    ");

    $stmt->bind_param("s", $code);
    $stmt->execute();

    $result = $stmt->get_result();

    if ($result->num_rows > 0) {

        // to mark the code as used
        $update = $conn->prepare("
            UPDATE Access_Code SET status='USED' WHERE code=?
        ");
        $update->bind_param("s", $code);
        $update->execute();

        echo "Verified. Student can register.";

    } else {
        echo "Invalid or already used code.";
    }

    $stmt->close();
}

// Now we close the connection to the database
$conn->close();

?>