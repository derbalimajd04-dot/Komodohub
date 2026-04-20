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

    $authStmt = $pdo->prepare("
        SELECT user_id, name, password_hash
        FROM users
        WHERE name = ? AND is_active = 1
        LIMIT 1
    ");
    $authStmt->execute([$username]);
    $user = $authStmt->fetch(PDO::FETCH_ASSOC);

    if (!$user) {
        exit("Invalid username.");
    }

    if (!password_verify($password, $user['password_hash'])) {
        exit("Invalid password.");
    }

    $stmt = $pdo->prepare("
        SELECT name
        FROM users
        WHERE is_active = 1 AND name <> ?
        ORDER BY name ASC
    ");
    $stmt->execute([$username]);

    while ($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
        echo $row['name'] . PHP_EOL;
    }

} catch (Throwable $e) {
    echo "ERROR: " . $e->getMessage();
}
?>