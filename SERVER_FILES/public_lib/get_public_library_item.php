<?php
header('Content-Type: application/json');
ini_set('display_errors', 1);
error_reporting(E_ALL);

$configPath = __DIR__ . '/config.ini';

if (!file_exists($configPath)) {
    echo json_encode(["error" => "config.ini not found."]);
    exit;
}

$config = parse_ini_file($configPath);

if ($config === false) {
    echo json_encode(["error" => "Failed to read config.ini"]);
    exit;
}

$host   = $config['db_host'] ?? '';
$dbname = $config['db_name'] ?? '';
$dbuser = $config['db_user'] ?? '';
$dbpass = $config['db_pass'] ?? '';

$id = isset($_GET['id']) ? (int)$_GET['id'] : 0;

if ($id <= 0) {
    echo json_encode(["error" => "Invalid id"]);
    exit;
}

try {
    $pdo = new PDO(
        "mysql:host=$host;dbname=$dbname;charset=utf8mb4",
        $dbuser,
        $dbpass,
        [PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION]
    );

    $stmt = $pdo->prepare("
        SELECT id, title, author, animal_name, species, habitat,
               conservation_status, content, image_url, created_at
        FROM public_library
        WHERE id = ?
        LIMIT 1
    ");
    $stmt->execute([$id]);
    $item = $stmt->fetch(PDO::FETCH_ASSOC);

    if (!$item) {
        echo json_encode(["error" => "Item not found"]);
        exit;
    }

    echo json_encode($item);

} catch (Throwable $e) {
    echo json_encode(["error" => $e->getMessage()]);
}
?>