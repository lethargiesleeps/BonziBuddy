using System.Text.Json.Serialization;

namespace BonzoBuddo.BonziAI.Tools;

public class WeatherForecast
{
    [JsonInclude]
    public float Temp { get; set; }
    
}