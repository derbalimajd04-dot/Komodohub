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

try {
    $pdo = new PDO(
        "mysql:host=$host;dbname=$dbname;charset=utf8mb4",
        $dbuser,
        $dbpass,
        [PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION]
    );

    $stmt = $pdo->query("
        SELECT id, title
        FROM public_library
        ORDER BY created_at DESC, title ASC
    ");

    while ($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
        echo $row['id'] . "|" . $row['title'] . PHP_EOL;
    }

} catch (Throwable $e) {
    echo "ERROR: " . $e->getMessage();
}
?>