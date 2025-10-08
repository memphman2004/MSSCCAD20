# 🌤️ Weather App - C# WinForms Application

A beginner-friendly C# Weather Application that provides real-time weather information, location detection, and world clock functionality.

## ✨ Features

- **Real-time Weather Data**: Get current weather conditions from anywhere in the world
- **Multiple Search Options**: Search by city name, state, country, zip code, or postal code
- **Default Location**: Starts with Beverly Hills, CA (90210) as the default location
- **Smart Search Detection**: Automatically detects if you're searching by zip code or location name
- **World Clock**: Live time display for 8 popular cities around the world
- **Beautiful UI**: Clean, modern interface with weather icons and color-coded information
- **Error Handling**: Comprehensive error handling with user-friendly messages

## 🚀 Getting Started

### Prerequisites

- **.NET 8.0 SDK** or later
- **Visual Studio 2022** or **Visual Studio Code** with C# extension
- **OpenWeatherMap API Key** (free tier available)

### Step 1: Get Your API Key

1. Visit [OpenWeatherMap](https://openweathermap.org/api)
2. Sign up for a free account
3. Go to your API keys section
4. Copy your API key

### Step 2: Configure the Application

1. Open `MainForm.cs`
2. Find this line:
   ```csharp
   private readonly string apiKey = "YOUR_API_KEY_HERE";
   ```
3. Replace `"YOUR_API_KEY_HERE"` with your actual API key:
   ```csharp
   private readonly string apiKey = "your_actual_api_key_here";
   ```

### Step 3: Build and Run

#### Using Visual Studio:
1. Open `WeatherApp.csproj` in Visual Studio
2. Press `F5` or click "Start Debugging"

#### Using Command Line:
```bash
# Navigate to the project directory
cd "Weather app C#"

# Restore packages
dotnet restore

# Build the project
dotnet build

# Run the application
dotnet run
```

## 🎯 How to Use

### Main Features:

1. **Default Location**: The app starts with Beverly Hills, CA (90210) as the default location
2. **Smart Search**: Type any of the following in the search box:
   - **City names**: "New York", "London", "Tokyo"
   - **City, State**: "Los Angeles, CA", "Miami, FL"
   - **Zip codes**: "90210", "10001", "SW1A 1AA" (UK)
   - **Countries**: "France", "Japan", "Australia"
   - **Postal codes**: "K1A 0A6" (Canada), "100-0001" (Japan)
3. **Auto-Detection**: The app automatically detects if you're searching by zip code or location name
4. **Refresh Data**: Click "Refresh" to get updated weather for the default location (90210)
5. **World Clock**: View current time in 8 major cities worldwide

### Weather Information Displayed:
- Current temperature
- Weather condition with icon
- "Feels like" temperature
- Humidity percentage
- Atmospheric pressure
- Wind speed

## 🏗️ Project Structure

```
Weather app C#/
├── WeatherApp.csproj          # Project file with dependencies
├── Program.cs                 # Application entry point
├── MainForm.cs                # Main application logic
├── MainForm.Designer.cs       # UI design and layout
└── README.md                  # This file
```

## 🔧 Technical Details

### Technologies Used:
- **.NET 8.0**: Latest .NET framework
- **WinForms**: Windows desktop UI framework
- **HttpClient**: For API calls
- **Newtonsoft.Json**: JSON parsing
- **OpenWeatherMap API**: Weather data source
- **IP-API**: Free IP geolocation service

### API Endpoints:
- **Weather**: `https://api.openweathermap.org/data/2.5/weather`
- **Geolocation**: `http://ip-api.com/json`

### Data Models:
- `WeatherData`: Main weather information
- `LocationData`: IP geolocation data
- `WorldClock`: Time zone information

## 🌍 World Clock Cities

The app displays current time for these cities:
- New York (America/New_York)
- London (Europe/London)
- Tokyo (Asia/Tokyo)
- Sydney (Australia/Sydney)
- Paris (Europe/Paris)
- Dubai (Asia/Dubai)
- Moscow (Europe/Moscow)
- Beijing (Asia/Shanghai)

## 🎨 UI Design

The application features:
- **Modern Color Scheme**: Blue and green accent colors
- **Responsive Layout**: Organized in panels for better structure
- **Weather Icons**: Emoji-based weather condition indicators
- **Status Updates**: Real-time status messages
- **Clean Typography**: Segoe UI font family

## 🛠️ Customization

### Adding More Cities to World Clock:
1. Open `MainForm.cs`
2. Find the `InitializeWorldClocks()` method
3. Add new `WorldClock` objects:
   ```csharp
   new WorldClock("City Name", "TimeZone/Id")
   ```

### Changing Weather Icons:
1. Find the `SetWeatherIcon()` method
2. Modify the switch statement to change emoji icons

### Styling Changes:
1. Open `MainForm.Designer.cs`
2. Modify colors, fonts, and layout properties

## 🐛 Troubleshooting

### Common Issues:

1. **"Error loading weather"**: Check your API key and internet connection
2. **"API key not configured"**: Make sure you've set your OpenWeatherMap API key in app.config
3. **"Could not find location"**: Try different search formats (city name, zip code, etc.)
4. **Build errors**: Ensure you have .NET 8.0 SDK installed

### API Rate Limits:
- OpenWeatherMap free tier: 1,000 calls/day
- IP-API: 1,000 requests/minute

## 📚 Learning Resources

This project demonstrates:
- **Async/Await**: Asynchronous programming patterns
- **HTTP Client**: Making API calls
- **JSON Parsing**: Working with API responses
- **WinForms**: Desktop application development
- **Error Handling**: Proper exception management
- **Timer Usage**: Real-time updates
- **Data Models**: Object-oriented design
- **Smart Input Validation**: Detecting different input types
- **Multiple API Endpoints**: Using different search methods

## 🤝 Contributing

Feel free to enhance this project by:
- Adding more weather details (forecast, UV index, etc.)
- Implementing weather maps
- Adding more cities to the world clock
- Improving the UI design
- Adding unit tests

## 📄 License

This project is open source and available under the MIT License.

## 🙏 Acknowledgments

- [OpenWeatherMap](https://openweathermap.org/) for weather data API
- [IP-API](http://ip-api.com/) for geolocation services
- Microsoft for .NET and WinForms frameworks

---

**Happy Coding! 🌤️**
