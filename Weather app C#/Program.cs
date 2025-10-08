using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("AllowAll");
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Weather API endpoints
app.MapGet("/api/weather/{location}", async (string location, HttpContext context) =>
{
    var httpClient = new HttpClient();
    var apiKey = "5f6f88a3611e47e007a0212df3609574";
    var baseUrl = "https://api.openweathermap.org/data/2.5/weather";
    
    try
    {
        string url;
        if (System.Text.RegularExpressions.Regex.IsMatch(location, @"^\d+$"))
        {
            // It's a zip code
            url = $"{baseUrl}?zip={location}&appid={apiKey}&units=metric";
        }
        else
        {
            // It's a location name
            url = $"{baseUrl}?q={location}&appid={apiKey}&units=metric";
        }
        
        var response = await httpClient.GetStringAsync(url);
        var weatherData = System.Text.Json.JsonSerializer.Deserialize<WeatherData>(response);
        
        return Results.Ok(weatherData);
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Error: {ex.Message}");
    }
});

app.MapGet("/api/worldclock", () =>
{
    var worldClocks = new List<WorldClock>
    {
        new WorldClock { CityName = "New York", TimeZoneId = "America/New_York" },
        new WorldClock { CityName = "London", TimeZoneId = "Europe/London" },
        new WorldClock { CityName = "Tokyo", TimeZoneId = "Asia/Tokyo" },
        new WorldClock { CityName = "Sydney", TimeZoneId = "Australia/Sydney" },
        new WorldClock { CityName = "Paris", TimeZoneId = "Europe/Paris" },
        new WorldClock { CityName = "Dubai", TimeZoneId = "Asia/Dubai" },
        new WorldClock { CityName = "Moscow", TimeZoneId = "Europe/Moscow" },
        new WorldClock { CityName = "Beijing", TimeZoneId = "Asia/Shanghai" }
    };
    
    foreach (var clock in worldClocks)
    {
        try
        {
            var time = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(clock.TimeZoneId));
            clock.CurrentTime = time.ToString("HH:mm:ss");
        }
        catch
        {
            clock.CurrentTime = "N/A";
        }
    }
    
    return Results.Ok(worldClocks);
});

app.Run();

public class WeatherData
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";
    
    [JsonPropertyName("main")]
    public WeatherMain Main { get; set; } = new();
    
    [JsonPropertyName("weather")]
    public WeatherInfo[] Weather { get; set; } = Array.Empty<WeatherInfo>();
    
    [JsonPropertyName("wind")]
    public WindInfo Wind { get; set; } = new();
    
    [JsonPropertyName("sys")]
    public SystemInfo? Sys { get; set; }
}

public class WeatherMain
{
    [JsonPropertyName("temp")]
    public double Temp { get; set; }
    
    [JsonPropertyName("feels_like")]
    public double FeelsLike { get; set; }
    
    [JsonPropertyName("humidity")]
    public int Humidity { get; set; }
    
    [JsonPropertyName("pressure")]
    public int Pressure { get; set; }
}

public class WeatherInfo
{
    [JsonPropertyName("main")]
    public string Main { get; set; } = "";
    
    [JsonPropertyName("description")]
    public string Description { get; set; } = "";
}

public class WindInfo
{
    [JsonPropertyName("speed")]
    public double Speed { get; set; }
}

public class SystemInfo
{
    [JsonPropertyName("country")]
    public string Country { get; set; } = "";
}

public class WorldClock
{
    public string CityName { get; set; } = "";
    public string TimeZoneId { get; set; } = "";
    public string CurrentTime { get; set; } = "";
}