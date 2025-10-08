# 🌤️ Weather App - Web Application (ASP.NET Core)

A modern web-based Weather Application built with ASP.NET Core that provides real-time weather data, location services, and world clock functionality accessible through your browser.

## ✅ Successfully Running on localhost:3001!

### 🌐 **Live Web Application**
- **URL**: http://localhost:3001
- **Status**: ✅ Running and functional
- **Default Location**: Beverly Hills, CA (90210)
- **Real-time Data**: ✅ Working with OpenWeatherMap API

## ✨ Features

- **Real-time Weather Data**: Get current weather conditions from anywhere in the world
- **Multiple Search Options**: Search by city name, state, country, zip code, or postal code
- **Smart Search Detection**: Automatically detects if you're searching by zip code or location name
- **World Clock**: Live time display for 8 popular cities around the world
- **Modern Web UI**: Beautiful, responsive web interface with weather icons and animations
- **REST API**: Clean API endpoints for programmatic access
- **Cross-platform**: Runs anywhere .NET 8 is supported

## 🚀 Running the Application

### Quick Start
```bash
cd "/Volumes/Mac Mini/Coding Projects/Weather app C#"
dotnet run --project WeatherWebApp.csproj --urls="http://localhost:3001"
```

### Access Points
- **Main App**: http://localhost:3001
- **API Documentation**: http://localhost:3001/swagger
- **Weather API**: http://localhost:3001/api/weather/{location}
- **World Clock API**: http://localhost:3001/api/worldclock

## 🎯 API Endpoints

### Weather API
```bash
# Search by zip code
GET /api/weather/90210

# Search by city name
GET /api/weather/London

# Search by city, state
GET /api/weather/Los Angeles,CA
```

**Response Example:**
```json
{
  "name": "Beverly Hills",
  "main": {
    "temp": 17.8,
    "feels_like": 18.0,
    "humidity": 91,
    "pressure": 1015
  },
  "weather": [{
    "main": "Mist",
    "description": "mist"
  }],
  "wind": {
    "speed": 3.1
  },
  "sys": {
    "country": "US"
  }
}
```

### World Clock API
```bash
GET /api/worldclock
```

**Response Example:**
```json
[
  {
    "cityName": "New York",
    "timeZoneId": "America/New_York", 
    "currentTime": "09:24:35"
  },
  {
    "cityName": "London",
    "timeZoneId": "Europe/London",
    "currentTime": "14:24:35"
  }
  // ... more cities
]
```

## 🌍 Supported Search Formats

- **US Zip Codes**: `90210`, `10001`, `60601`
- **International Postal Codes**: `SW1A 1AA` (UK), `K1A 0A6` (Canada)
- **City Names**: `Tokyo`, `Paris`, `Mumbai`
- **City, State**: `Los Angeles,CA`, `Miami, FL`
- **Countries**: `France`, `Japan`, `Germany`

## 🎨 Web Interface Features

- **Responsive Design**: Works on desktop, tablet, and mobile
- **Real-time Updates**: World clock updates every second
- **Weather Icons**: Dynamic emoji icons based on weather conditions
- **Modern UI**: Bootstrap 5 with custom gradients and animations
- **Loading States**: Smooth loading indicators
- **Error Handling**: User-friendly error messages

## 🔧 Technical Stack

- **Backend**: ASP.NET Core 8.0
- **Frontend**: HTML5, CSS3, JavaScript, Bootstrap 5
- **API Integration**: OpenWeatherMap API
- **JSON Parsing**: System.Text.Json
- **Hosting**: Kestrel web server
- **Port**: 3001 (configurable)

## 📂 Project Structure

```
WeatherWebApp/
├── Controllers/
│   └── HomeController.cs
├── Program.cs                 # Main application startup
├── WeatherWebApp.csproj      # Project configuration
├── Views/
│   ├── Home/
│   │   └── Index.cshtml      # Main page view
│   └── Shared/
│       └── _Layout.cshtml    # Layout with weather UI
└── Properties/
    └── launchSettings.json   # Launch configuration
```

## 🎯 Demo Results

**Current Weather Data** (Real-time):
- **Beverly Hills, US (90210)**:
  - 🌡️ Temperature: 17.8°C
  - 🌤️ Condition: MIST
  - 💧 Humidity: 91%
  - 💨 Wind: 3.1 m/s

**World Clock**:
- 🕐 New York: 09:24:35
- 🕐 London: 14:24:35
- 🕐 Tokyo: 22:24:35
- 🕐 Sydney: 23:24:35

## 🚀 Ready to Use!

The Weather App web application is now fully functional and running on **localhost:3001**. You can:

1. **Open your browser** and go to http://localhost:3001
2. **Search for weather** using any city, zip code, or country
3. **View real-time data** including temperature, humidity, wind speed
4. **See world clocks** updating every second
5. **Use the API** for programmatic access

**Status**: ✅ Successfully deployed and running!
