# Простая установка .NET SDK через winget
Write-Host "=== Установка .NET SDK через winget ===" -ForegroundColor Green

# Проверяем наличие winget
try {
    $wingetVersion = & winget --version 2>&1
    Write-Host "✅ winget найден: $wingetVersion" -ForegroundColor Green
} catch {
    Write-Host "❌ winget не найден. Установка через winget невозможна." -ForegroundColor Red
    Write-Host "Попробуйте установить .NET SDK вручную с https://dotnet.microsoft.com/download" -ForegroundColor Yellow
    exit 1
}

# Устанавливаем .NET SDK
Write-Host "Установка .NET SDK..." -ForegroundColor Yellow
try {
    & winget install Microsoft.DotNet.SDK.8 --accept-package-agreements --accept-source-agreements
    Write-Host "✅ .NET SDK установлен!" -ForegroundColor Green
} catch {
    Write-Host "❌ Ошибка при установке через winget" -ForegroundColor Red
    Write-Host "Попробуйте установить вручную с https://dotnet.microsoft.com/download" -ForegroundColor Yellow
    exit 1
}

# Обновляем PATH
Write-Host "Обновление переменных окружения..." -ForegroundColor Yellow
$env:PATH = [System.Environment]::GetEnvironmentVariable("PATH", "Machine") + ";" + [System.Environment]::GetEnvironmentVariable("PATH", "User")

# Проверяем установку
Write-Host "Проверка установки..." -ForegroundColor Yellow
try {
    $dotnetVersion = & dotnet --version
    Write-Host "✅ .NET SDK успешно установлен! Версия: $dotnetVersion" -ForegroundColor Green
    
    # Запускаем приложение
    Write-Host "Запуск DigiMediaStore..." -ForegroundColor Yellow
    Set-Location "DigiMediaStore"
    & dotnet run
} catch {
    Write-Host "❌ Ошибка при проверке .NET SDK" -ForegroundColor Red
    Write-Host "Попробуйте перезапустить PowerShell" -ForegroundColor Yellow
}
