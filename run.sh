#!/bin/bash

echo "========================================"
echo "   Weather App - Build and Run Script"
echo "========================================"
echo

echo "Checking .NET installation..."
if ! command -v dotnet &> /dev/null; then
    echo "ERROR: .NET SDK not found. Please install .NET 8.0 SDK or later."
    echo "Download from: https://dotnet.microsoft.com/download"
    exit 1
fi

dotnet --version

echo
echo "Restoring NuGet packages..."
dotnet restore
if [ $? -ne 0 ]; then
    echo "ERROR: Failed to restore packages."
    exit 1
fi

echo
echo "Building the application..."
dotnet build
if [ $? -ne 0 ]; then
    echo "ERROR: Build failed."
    exit 1
fi

echo
echo "Build successful! Starting the Weather App..."
echo
echo "IMPORTANT: Make sure you have configured your OpenWeatherMap API key"
echo "in the app.config file before running the application."
echo
read -p "Press Enter to continue..."

dotnet run
