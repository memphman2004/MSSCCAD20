@echo off
echo ========================================
echo    Weather App - Build and Run Script
echo ========================================
echo.

echo Checking .NET installation...
dotnet --version
if %errorlevel% neq 0 (
    echo ERROR: .NET SDK not found. Please install .NET 8.0 SDK or later.
    echo Download from: https://dotnet.microsoft.com/download
    pause
    exit /b 1
)

echo.
echo Restoring NuGet packages...
dotnet restore
if %errorlevel% neq 0 (
    echo ERROR: Failed to restore packages.
    pause
    exit /b 1
)

echo.
echo Building the application...
dotnet build
if %errorlevel% neq 0 (
    echo ERROR: Build failed.
    pause
    exit /b 1
)

echo.
echo Build successful! Starting the Weather App...
echo.
echo IMPORTANT: Make sure you have configured your OpenWeatherMap API key
echo in the app.config file before running the application.
echo.
pause

dotnet run
