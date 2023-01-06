using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace BonzoBuddo.Helpers;

public static class ApiHelper
{
    public static float GetWeather(string city, WeatherUnits unit)
    {
        var unitType = "";
        switch (unit)
        {
            case WeatherUnits.Celcius:
                unitType = "metric";
                break;
            case WeatherUnits.Farrenheit:
                unitType = "imperial";
                break;
            case WeatherUnits.Kelvin:
                unitType = "kelvin";
                break;
        }

        try
        {
            var bytes = Encoding.UTF8.GetBytes(city);
            city = Encoding.UTF8.GetString(bytes);
            var client = new HttpClient();
            var response = client.GetStringAsync(
                $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=79002f649b41ab93f1bc47f86efc5fff&units={unitType}"
            );
            var data = JsonNode.Parse(response.Result)!;
            var currentTemp = data.Root["main"]?["temp"];
            return float.Parse(currentTemp.ToString());
        }
        catch (JsonException e)
        {
            Debug.WriteLine(e.Message);
            return 100f;
        }
    }
}

public enum WeatherUnits
{
    Celcius,
    Farrenheit,
    Kelvin
}