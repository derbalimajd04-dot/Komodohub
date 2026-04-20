<?php
header('Content-Type: text/plain');
ini_set('display_errors', 1);
error_reporting(E_ALL);

$configPath = __DIR__ . '/config.ini';
if (!file_exists($configPath)) {
    exit("config.ini not found.");
}

$config = parse_ini_file($configPath);
if ($config === false) {
    exit("Failed to read config.ini");
}

$host   = $config['db_host'] ?? '';
$dbname = $config['db_name'] ?? '';
$dbuser = $config['db_user'] ?? '';
$dbpass = $config['db_pass'] ?? '';

if ($host === '' || $dbname === '' || $dbuser === '') {
    exit("Invalid database config.");
}

$secretKey = "12345678901234567890123456789012"; // 32 chars
$cipher = "AES-256-CBC";

$username = $_GET['username'] ?? '';
$password = $_GET['password'] ?? '';
$sendTo   = $_GET['sendTo'] ?? '';
$message  = $_GET['message'] ?? '';

if ($username === '' || $password === '' || $sendTo === '' || $message === '') {
    exit("Missing username or password.");
}

try {
    $pdo = new PDO(
        "mysql:host=$host;dbname=$dbname;charset=utf8mb4",
        $dbuser,
        $dbpass,
        [PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION]
    );

    $senderStmt = $pdo->prepare("
        SELECT user_id, name, password_hash
        FROM users
        WHERE name = ? AND is_active = 1
        LIMIT 1
    ");
    $senderStmt->execute([$username]);
    $sender = $senderStmt->fetch(PDO::FETCH_ASSOC);

    if (!$sender) {
        exit("Invalid username.");
    }

    if (!password_verify($password, $sender['password_hash'])) {
        exit("Invalid password.");
    }

    $recipientStmt = $pdo->prepare("
        SELECT user_id, name, messages
        FROM users
        WHERE name = ? AND is_active = 1
        LIMIT 1
    ");
    $recipientStmt->execute([$sendTo]);
    $recipient = $recipientStmt->fetch(PDO::FETCH_ASSOC);

    if (!$recipient) {
        exit("Recipient not found.");
    }

    $timestamp = date("Y-m-d H:i:s");
    $fullMessage = "[FROM: " . $sender['name'] . " | AT: " . $timestamp . "] " . $message;

    $iv = random_bytes(16);

    $encrypted = openssl_encrypt(
        $fullMessage,
        $cipher,
        $secretKey,
        OPENSSL_RAW_DATA,
        $iv
    );

    if ($encrypted === false) {
        exit("Encryption failed.");
    }

    $storedLine = base64_encode($iv) . ":" . base64_encode($encrypted);

    $existingMessages = $recipient['messages'] ?? '';

    if ($existingMessages === null || trim($existingMessages) === '') {
        $newMessages = $storedLine;
    } else {
        $newMessages = $existingMessages . PHP_EOL . $storedLine;
    }

    $updateStmt = $pdo->prepare("
        UPDATE users
        SET messages = ?
        WHERE user_id = ?
    ");
    $updateStmt->execute([$newMessages, $recipient['user_id']]);

    echo "Message added successfully.";

} catch (Throwable $e) {
    echo "ERROR: " . $e->getMessage();
}
?>