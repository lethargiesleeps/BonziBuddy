﻿using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace BonzoBuddo.Helpers;

/// <summary>
///     Static helper class for interacting with third-party APIs and JSON parsing.
/// </summary>
public static class ApiHelper
{
    public static string GetFact()
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("X-Api-Key", Keys.NinjaKey());
        try
        {
            var response = client.GetStringAsync("https://api.api-ninjas.com/v1/facts?limit=1");
            var data = JsonNode.Parse(response.Result)!;
            var fact = data.AsArray()[0]["fact"];
            return fact.ToJsonString();
        }
        catch (JsonException e)
        {
            Debug.WriteLine(e.Message);
            return "I cannot connect to the internet.";
        }
        finally
        {
            client.Dispose();
        }
    }

    public static string GetJoke()
    {
        var client = new HttpClient();
        try
        {
            var response =
                client.GetStringAsync(
                    "https://v2.jokeapi.dev/joke/Any?blacklistFlags=nsfw,political,explicit&type=single");
            var data = JsonNode.Parse(response.Result)!;
            var joke = data.Root["joke"];
            return joke.ToString();
        }
        catch (JsonException e)
        {
            Debug.WriteLine(e.Message);
            return "I cannot connect to the internet.";
        }
        finally
        {
            client.Dispose();
        }
    }

    /// <summary>
    ///     Uses OpenWeather API call to retrieve weather for the user.
    /// </summary>
    /// <param name="city">City to query.</param>
    /// <param name="unit">Degree unit to use.</param>
    /// <returns>The current weather as a float</returns>
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
                $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={Keys.OpenWeatherKey()}&units={unitType}"
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

/// <summary>
///     Different units to be used to retrieve the weather.
/// </summary>
public enum WeatherUnits
{
    //TODO: User can change which unit they want.
    Celcius,
    Farrenheit,
    Kelvin
}