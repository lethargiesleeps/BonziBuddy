using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using BonzoBuddo.BonziAI.Speech;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;

namespace BonzoBuddo.Helpers;

/// <summary>
///     Static helper class for interacting with third-party APIs and JSON parsing.
/// </summary>
public static class ApiHelper
{
    /// <summary>
    /// Gets a random news article from NewsCatcher.
    /// </summary>
    /// <param name="keyWords">Keywords used in query.</param>
    /// <param name="countryCode">Country's code.</param>
    /// <param name="category">Category of article topic.</param>
    /// <returns></returns>
    public static Dictionary<string, string> GetNews(string keyWords, string countryCode, string category)
    {
        var newsDictionary = new Dictionary<string, string>();
        string url = "";
        if (countryCode.Equals("nn"))
            countryCode = "us"; //Change this to default country later
        
        if (string.IsNullOrEmpty(keyWords))
        {
            url = $"https://api.newscatcherapi.com/v2/latest_headlines?countries={countryCode.ToUpper()}&topic={category.ToLower()}";
        }
        else
        {
            var parsedKeywords = Uri.EscapeDataString(keyWords);
            url =
                $"https://api.newscatcherapi.com/v2/search?q={parsedKeywords}&countries={countryCode.ToUpper()}&topic={category.ToLower()}";
        }
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("x-api-key", Keys.NewsKey());
        try
        {
            var response = client.GetStringAsync(url);
            var data = JsonNode.Parse(response.Result)!;
            var articles = data.Root["articles"].AsArray();
            if (articles.Count <= 0)
            {
                newsDictionary.Add("NoResults", Phrases.ErrorMessages()["NoResults"]);
            }
            else
            {
                //TODO: Add some randomly generated flavour.
                RandomNumberHelper.SetIndex(articles.Count);
                var selectedArticle = articles[RandomNumberHelper.CurrentValue];
                newsDictionary.Add("Title", $"It's titled: {selectedArticle["title"]}");
                newsDictionary.Add("Author", $"Here's one from {selectedArticle["author"]}.");
                newsDictionary.Add("Excerpt", $"{selectedArticle["excerpt"].ToString()}.");
                newsDictionary.Add("Summary", selectedArticle["summary"].ToString());
            }
            

        }
        catch (AggregateException e)
        {
            Debug.WriteLine("Nope");
        }
        return newsDictionary;

    }

    /// <summary>
    /// Gets a random fun fact from Ninja API.
    /// </summary>
    /// <returns>A fact for Bonzi to say.</returns>
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

    /// <summary>
    /// Retrieves a random joke from joke api.
    /// </summary>
    /// <returns>A joke for Bonzi to say.</returns>
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