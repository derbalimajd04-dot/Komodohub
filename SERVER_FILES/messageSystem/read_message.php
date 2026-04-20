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

$secretKey = "12345678901234567890123456789012";
$cipher = "AES-256-CBC";

$username = $_GET['username'] ?? '';
$password = $_GET['password'] ?? '';

if ($username === '' || $password === '') {
    exit("Missing username or password.");
}

try {
    $pdo = new PDO(
        "mysql:host=$host;dbname=$dbname;charset=utf8mb4",
        $dbuser,
        $dbpass,
        [PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION]
    );

    $stmt = $pdo->prepare("
        SELECT user_id, name, password_hash, messages
        FROM users
        WHERE name = ? AND is_active = 1
        LIMIT 1
    ");
    $stmt->execute([$username]);
    $user = $stmt->fetch(PDO::FETCH_ASSOC);

    if (!$user) {
        exit("Invalid username.");
    }

    if (!password_verify($password, $user['password_hash'])) {
        exit("Invalid password.");
    }

    $messagesBlob = $user['messages'] ?? '';

    if ($messagesBlob === null || trim($messagesBlob) === '') {
        exit("");
    }

    $lines = preg_split("/\r\n|\n|\r/", $messagesBlob);

    foreach ($lines as $line) {
        $line = trim($line);

        if ($line === '') {
            continue;
        }

        $parts = explode(":", $line, 2);
        if (count($parts) !== 2) {
            echo "[Invalid line]" . PHP_EOL;
            continue;
        }

        $iv = base64_decode($parts[0], true);
        $encryptedData = base64_decode($parts[1], true);

        if ($iv === false || $encryptedData === false) {
            echo "[Corrupted line]" . PHP_EOL;
            continue;
        }

        $decrypted = openssl_decrypt(
            $encryptedData,
            $cipher,
            $secretKey,
            OPENSSL_RAW_DATA,
            $iv
        );

        if ($decrypted === false) {
            echo "[Decryption failed]" . PHP_EOL;
        } else {
            echo $decrypted . PHP_EOL;
        }
    }

} catch (Throwable $e) {
    echo "ERROR: " . $e->getMessage();
}
?>