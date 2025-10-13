@echo off
echo Запуск DigiMediaStore API...

REM Попытка найти и запустить через Visual Studio Developer Command Prompt
if exist "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\Tools\VsDevCmd.bat" (
    echo Используем Visual Studio 2022 Community...
    call "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\Tools\VsDevCmd.bat"
    cd /d "%~dp0DigiMediaStore"
    dotnet run
) else if exist "C:\Program Files\Microsoft Visual Studio\2022\Professional\Common7\Tools\VsDevCmd.bat" (
    echo Используем Visual Studio 2022 Professional...
    call "C:\Program Files\Microsoft Visual Studio\2022\Professional\Common7\Tools\VsDevCmd.bat"
    cd /d "%~dp0DigiMediaStore"
    dotnet run
) else if exist "C:\Program Files\Microsoft Visual Studio\2022\Enterprise\Common7\Tools\VsDevCmd.bat" (
    echo Используем Visual Studio 2022 Enterprise...
    call "C:\Program Files\Microsoft Visual Studio\2022\Enterprise\Common7\Tools\VsDevCmd.bat"
    cd /d "%~dp0DigiMediaStore"
    dotnet run
) else (
    echo Visual Studio 2022 не найдена. Попробуйте запустить через Visual Studio IDE.
    echo Откройте файл DigiMediaStore.sln в Visual Studio и нажмите F5.
    pause
)
