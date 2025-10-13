@echo off
echo === Запуск DigiMediaStore через Visual Studio ===

REM Проверяем наличие Visual Studio
if exist "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\devenv.exe" (
    echo Найдена Visual Studio 2022 Community
    set "VS_PATH=C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\devenv.exe"
) else if exist "C:\Program Files\Microsoft Visual Studio\2022\Professional\Common7\IDE\devenv.exe" (
    echo Найдена Visual Studio 2022 Professional
    set "VS_PATH=C:\Program Files\Microsoft Visual Studio\2022\Professional\Common7\IDE\devenv.exe"
) else if exist "C:\Program Files\Microsoft Visual Studio\2022\Enterprise\Common7\IDE\devenv.exe" (
    echo Найдена Visual Studio 2022 Enterprise
    set "VS_PATH=C:\Program Files\Microsoft Visual Studio\2022\Enterprise\Common7\IDE\devenv.exe"
) else (
    echo Visual Studio 2022 не найдена!
    echo Установите Visual Studio 2022 или .NET SDK
    pause
    exit /b 1
)

echo Запуск Visual Studio с проектом DigiMediaStore.sln...
start "" "%VS_PATH%" "DigiMediaStore.sln"

echo.
echo Visual Studio запущена!
echo.
echo Инструкции для запуска Swagger:
echo 1. В Visual Studio выберите проект DigiMediaStore
echo 2. Нажмите F5 или Ctrl+F5 для запуска
echo 3. Браузер откроется автоматически на http://localhost:5200/swagger
echo.
echo Если браузер не открылся, перейдите по адресу:
echo http://localhost:5200/swagger
echo.
pause
