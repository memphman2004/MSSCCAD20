# Weather App Background Videos

## 📁 Directory Structure

Save your weather videos in the following folders:

```
wwwroot/videos/
├── mist/              ← Foggy/misty videos
├── rain/              ← Rainy weather videos  
├── clouds/            ← Cloudy sky videos
├── snow/              ← Snowy winter videos
├── clear-sky/         ← Sunny/clear weather videos
└── thunderstorm/      ← Storm/thunderstorm videos
```

## 🎬 Video File Requirements

### **Recommended Settings:**
- **Format**: MP4 (best compatibility)
- **Resolution**: 1920x1080 (1080p) minimum
- **Compression**: H.264 codec
- **Audio**: Remove audio or keep very low volume
- **Duration**: 10-30 seconds recommended
- **File Size**: Under 50MB per video for good performance

### **Video Guidelines:**
- **Loop**: Videos should loop seamlessly (same start/end frame)
- **Focus**: Slow-moving or static shots work best
- **Lighting**: Consistent lighting throughout the clip
- **Stability**: Use tripod/stabilization for best results

## 📝 How to Add Your Videos

### **1. Save Your Videos:**
```
📁 /videos/mist/mist-forest.mp4
📁 /videos/rain/rain-streets.mp4  
📁 /videos/snow/snow-mountains.mp4
📁 /videos/clear-sky/sunny-hills.mp4
```

### **2. Update CSS in `Views/Shared/_Layout.cshtml`:**

Find each weather condition (like `body.mist {`) and replace:
```css
/* BEFORE */
background-image: url('https://unsplash.com/image-url');

/* AFTER */  
background-image: url('/videos/mist/mist-forest.mp4');
```

### **3. Example Updates:**

**Mist Weather:**
```css
body.mist { 
    background-image: url('/videos/mist/mist-forest.mp4');
}
```

**Rain Weather:**
```css
body.shower-rain { 
    background-image: url('/videos/rain/rain-streets.mp4');
}
```

**Clear Sky:**
```css
body.clear-sky { 
    background-image: url('/videos/clear-sky/sunny-hills.mp4');
}
```

## 🔄 Current Weather Video Status

| Weather | Current Type | Video Setup |
|---------|--------------|-------------|
| **Mist** | 🌫️ **ACTIVE** - Beverly Hills | Ready for video replacement |
| Rain | 🌧️ Image | Ready for `rain/` folder |
| Clouds | ☁️ Image | Ready for `clouds/` folder |
| Snow | ❄️ Image | Ready for `snow/` folder |
| Clear Sky | ☀️ Image | Ready for `clear-sky/` folder |
| Thunderstorm | ⛈️ Image | Ready for `thunderstorm/` folder |

## 🚀 Testing Your Videos

1. **Save** your video file: `/videos/mist/mist-forest.mp4`
2. **Update** the CSS to use the video URL
3. **Restart** the server: `dotnet run --project WeatherWebApp.csproj --urls="http://localhost:3001"`
4. **Test** at: http://localhost:3001

The mist weather in Beverly Hills will now show your video background!

---

**📞 Need Help?**
- Video formats: Use MP4 with H.264 codec
- Performance: Keep files under 50MB
- Looping: Ensure seamless start/end transitions
