# Скрипт для запуска Docker Desktop и ожидания инициализации
Write-Host "🚀 Запуск Docker Desktop..." -ForegroundColor Cyan

# Проверка установки
$dockerPath = "C:\Program Files\Docker\Docker\Docker Desktop.exe"
if (-not (Test-Path $dockerPath)) {
    Write-Host "❌ Docker Desktop не найден!" -ForegroundColor Red
    Write-Host "Установите Docker Desktop: https://www.docker.com/products/docker-desktop/" -ForegroundColor Yellow
    exit 1
}

# Проверка, не запущен ли уже
$dockerProcess = Get-Process -Name "Docker Desktop" -ErrorAction SilentlyContinue
if ($dockerProcess) {
    Write-Host "✅ Docker Desktop уже запущен (PID: $($dockerProcess.Id))" -ForegroundColor Green
} else {
    Write-Host "Запускаю Docker Desktop..." -ForegroundColor Yellow
    Start-Process $dockerPath
    Write-Host "✅ Docker Desktop запущен" -ForegroundColor Green
}

# Ожидание инициализации
Write-Host "`n⏳ Ожидание инициализации Docker Desktop..." -ForegroundColor Yellow
Write-Host "   Это может занять 2-3 минуты при первом запуске" -ForegroundColor Cyan
Write-Host "   Docker создаст свои WSL дистрибутивы автоматически" -ForegroundColor Cyan

$maxWaitTime = 180 # 3 минуты
$checkInterval = 5 # проверка каждые 5 секунд
$elapsed = 0
$dockerReady = $false

while ($elapsed -lt $maxWaitTime -and -not $dockerReady) {
    Start-Sleep -Seconds $checkInterval
    $elapsed += $checkInterval
    
    try {
        $result = docker ps 2>&1
        if ($LASTEXITCODE -eq 0) {
            $dockerReady = $true
            Write-Host "`n✅ Docker готов к работе!" -ForegroundColor Green
        } else {
            $progress = [math]::Min(($elapsed / $maxWaitTime) * 100, 100)
            Write-Host "   Ожидание... ($([math]::Floor($elapsed))s / $maxWaitTime s)" -ForegroundColor Gray
        }
    } catch {
        $progress = [math]::Min(($elapsed / $maxWaitTime) * 100, 100)
        Write-Host "   Ожидание... ($([math]::Floor($elapsed))s / $maxWaitTime s)" -ForegroundColor Gray
    }
}

if (-not $dockerReady) {
    Write-Host "`n⚠️  Docker еще не готов после $maxWaitTime секунд" -ForegroundColor Yellow
    Write-Host "`nПроверьте:" -ForegroundColor Yellow
    Write-Host "   1. Иконка Docker в трее (правый нижний угол)" -ForegroundColor White
    Write-Host "   2. Если иконка мигает - подождите еще 1-2 минуты" -ForegroundColor White
    Write-Host "   3. Если есть ошибки - откройте Docker Desktop и проверьте" -ForegroundColor White
    Write-Host "`nПопробуйте проверить вручную:" -ForegroundColor Cyan
    Write-Host "   docker ps" -ForegroundColor White
} else {
    Write-Host "`n📊 Информация о Docker:" -ForegroundColor Cyan
    docker version --format "   Docker: {{.Server.Version}}"
    
    Write-Host "`n📦 Проверка WSL дистрибутивов Docker:" -ForegroundColor Cyan
    wsl --list --verbose 2>&1 | Select-String "docker"
    
    Write-Host "`n✅ Все готово! Теперь можно запускать проект:" -ForegroundColor Green
    Write-Host "   cd C:\Users\rakit\Documents\GitHub\DigiMediaStore" -ForegroundColor Cyan
    Write-Host "   docker-compose up --build" -ForegroundColor Cyan
}







