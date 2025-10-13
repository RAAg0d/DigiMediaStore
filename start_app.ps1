Write-Host "Запуск DigiMediaStore API..." -ForegroundColor Green

# Попытка найти Visual Studio Developer Command Prompt
$vsPaths = @(
    "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\Tools\VsDevCmd.bat",
    "C:\Program Files\Microsoft Visual Studio\2022\Professional\Common7\Tools\VsDevCmd.bat",
    "C:\Program Files\Microsoft Visual Studio\2022\Enterprise\Common7\Tools\VsDevCmd.bat"
)

$vsPath = $null
foreach ($path in $vsPaths) {
    if (Test-Path $path) {
        $vsPath = $path
        Write-Host "Найдена Visual Studio: $path" -ForegroundColor Yellow
        break
    }
}

if ($vsPath) {
    Write-Host "Запуск через Visual Studio Developer Command Prompt..." -ForegroundColor Yellow
    
    # Переходим в папку проекта
    Set-Location "DigiMediaStore"
    
    # Запускаем через cmd с настройками Visual Studio
    $cmd = "cmd /c `"$vsPath`" && dotnet run"
    Invoke-Expression $cmd
} else {
    Write-Host "Visual Studio не найдена!" -ForegroundColor Red
    Write-Host "Попробуйте один из следующих способов:" -ForegroundColor Yellow
    Write-Host "1. Откройте DigiMediaStore.sln в Visual Studio и нажмите F5" -ForegroundColor Cyan
    Write-Host "2. Установите .NET SDK с https://dotnet.microsoft.com/download" -ForegroundColor Cyan
    Write-Host "3. Используйте Visual Studio Code с расширением C#" -ForegroundColor Cyan
    
    Write-Host "`nНажмите любую клавишу для выхода..."
    $null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
}
