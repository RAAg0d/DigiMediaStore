# Скрипт для установки .NET SDK
Write-Host "=== Установка .NET SDK для DigiMediaStore ===" -ForegroundColor Green

# Проверяем архитектуру системы
$arch = if ([Environment]::Is64BitOperatingSystem) { "x64" } else { "x86" }
Write-Host "Архитектура системы: $arch" -ForegroundColor Yellow

# URL для скачивания .NET 8 SDK
$downloadUrl = "https://download.visualstudio.microsoft.com/download/pr/4b2d9b05-2c34-4c7e-9f76-8a6e2757e79e/8b4ad5b5edc4e4f1c5b5c5d5e5f5a5b5c/dotnet-sdk-8.0.404-win-x64.exe"

Write-Host "Скачивание .NET 8 SDK..." -ForegroundColor Yellow
Write-Host "URL: $downloadUrl" -ForegroundColor Cyan

# Создаем временную папку
$tempDir = "$env:TEMP\dotnet_install"
if (!(Test-Path $tempDir)) {
    New-Item -ItemType Directory -Path $tempDir -Force
}

# Имя файла для скачивания
$installerFile = "$tempDir\dotnet-sdk-installer.exe"

try {
    # Скачиваем установщик
    Write-Host "Скачивание установщика..." -ForegroundColor Yellow
    Invoke-WebRequest -Uri $downloadUrl -OutFile $installerFile -UseBasicParsing
    
    Write-Host "Установщик скачан: $installerFile" -ForegroundColor Green
    
    # Запускаем установщик
    Write-Host "Запуск установщика..." -ForegroundColor Yellow
    Write-Host "Пожалуйста, следуйте инструкциям установщика." -ForegroundColor Cyan
    
    Start-Process -FilePath $installerFile -Wait
    
    Write-Host "Установка завершена!" -ForegroundColor Green
    
    # Обновляем PATH
    Write-Host "Обновление переменных окружения..." -ForegroundColor Yellow
    $env:PATH = [System.Environment]::GetEnvironmentVariable("PATH", "Machine") + ";" + [System.Environment]::GetEnvironmentVariable("PATH", "User")
    
    # Проверяем установку
    Write-Host "Проверка установки..." -ForegroundColor Yellow
    $dotnetVersion = & dotnet --version 2>&1
    if ($LASTEXITCODE -eq 0) {
        Write-Host "✅ .NET SDK успешно установлен! Версия: $dotnetVersion" -ForegroundColor Green
        
        # Запускаем приложение
        Write-Host "Запуск DigiMediaStore..." -ForegroundColor Yellow
        Set-Location "DigiMediaStore"
        & dotnet run
    } else {
        Write-Host "❌ Ошибка при проверке .NET SDK" -ForegroundColor Red
        Write-Host "Попробуйте перезапустить PowerShell и выполнить команду: dotnet --version" -ForegroundColor Yellow
    }
    
} catch {
    Write-Host "❌ Ошибка при скачивании или установке: $($_.Exception.Message)" -ForegroundColor Red
    Write-Host "Попробуйте скачать .NET SDK вручную с https://dotnet.microsoft.com/download" -ForegroundColor Yellow
}

Write-Host "`nНажмите любую клавишу для выхода..." -ForegroundColor Cyan
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
