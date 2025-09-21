
@echo off
set DEST=%1
if "%DEST%"=="" set DEST=%USERPROFILE%\Extreme4X_MegaFusion_install
mkdir "%DEST%"
xcopy * "%DEST%" /E /I /Y
echo Installation complete. To run: dotnet run --project "%DEST%" -- 2025
