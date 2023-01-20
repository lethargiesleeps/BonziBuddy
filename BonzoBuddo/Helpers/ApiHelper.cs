using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using BonzoBuddo.BonziAI.Speech;

namespace BonzoBuddo.Helpers;

/// <summary>
///     Static helper class for interacting with third-party APIs and JSON parsing.
/// </summary>
public static class ApiHelper
{

    public static string GetRandomWord()
    {
        var returnValue = string.Empty;
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("X-Api-Key", Keys.NinjaKey());
        try
        {
            var response = client.GetStringAsync($"https://api.api-ninjas.com/v1/randomword");
            var data = JsonNode.Parse(response.Result!);
            returnValue = data.Root["word"]!.ToString();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);

        }
        finally
        {
            client.Dispose();
        }
        return returnValue;
    }
    /// <summary>
    ///     Returns a definition of a word using Ninja API. If 'thesaurus' is true, a new call is made to retrieve to a
    ///     different API to retrieve synonyms and antonyms.
    /// </summary>
    /// <param name="word">The word to be searched.</param>
    /// <param name="thesaurus">Whether to use thesaurus API to retrieve synonyms and antonyms.</param>
    /// <returns>Definition of searched word, synonyms and antonyms.</returns>
    public static Dictionary<string, string> GetWordDefinition(string word, bool thesaurus = false)
    {
        var returnDictionary = new Dictionary<string, string>();
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("X-Api-Key", Keys.NinjaKey());
        try
        {
            var response = client.GetStringAsync($"https://api.api-ninjas.com/v1/dictionary?word={word}");
            var data = JsonNode.Parse(response.Result)!;
            var hasDefinition = bool.Parse(data.Root["valid"]!.ToString());
            if (hasDefinition)
            {
                var definition = data.Root["definition"]!.ToString();
                var definitionWords = definition.Split(' ');
                if (definitionWords.Length > 100)
                {
                    var sb = new StringBuilder();
                    var index = 0;
                    while (index <= 75)
                    {
                        sb.Append($"{definitionWords[index]} ");
                        index++;
                    }

                    sb.Append($"...\nThere is more information on {word}, but I don't want to bore you.");
                    definition = sb.ToString();
                }

                returnDictionary.Add("Definition", $"Here is the definition for {word}: {definition}");
                if (thesaurus)
                    try
                    {
                        response = client.GetStringAsync($"https://api.api-ninjas.com/v1/thesaurus?word={word}");
                        data = JsonNode.Parse(response.Result!);
                        var synonyms = data!.Root["synonyms"]!.AsArray();
                        var sb = new StringBuilder();
                        foreach (var t in synonyms)
                            sb.Append($"{t},\n");
                        sb.Replace('_', ' ');
                        var synonymPhrase = synonyms.Count <= 0
                            ? $"There are no synonyms I can think of for {word}."
                            : $"Here are synonyms for {word}:\n{sb}";
                        returnDictionary.Add("Synonyms", synonymPhrase);
                        sb.Clear();
                        var antonyms = data!.Root["antonyms"]!.AsArray();
                        foreach (var a in antonyms)
                            sb.Append($"{a},\n");
                        sb.Replace('_', ' ');


                        var antonymPhrase = antonyms.Count <= 0
                            ? $"There are no antonyms I can think of for {word}."
                            : $"Here are antonyms for {word}:\nn{sb}";
                        returnDictionary.Add("Antonyms", antonymPhrase);
                        returnDictionary.Add("Post", Phrases.PostDictionary(word));
                    }
                    catch (AggregateException ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
            }
            else
            {
                returnDictionary.Add("Definition",
                    $"I could not find a definition for {word}. Try checking your spelling.");
            }
        }
        catch (AggregateException ex)
        {
            Debug.WriteLine(ex.Message);
        }
        finally
        {
            client.Dispose();
        }

        return returnDictionary;
    }

    /// <summary>
    ///     Gets a random news article from NewsCatcher.
    /// </summary>
    /// <param name="keyWords">Keywords used in query.</param>
    /// <param name="countryCode">Country's code.</param>
    /// <param name="category">Category of article topic.</param>
    /// <returns></returns>
    public static Dictionary<string, string> GetNews(string keyWords, string countryCode, string category)
    {
        var newsDictionary = new Dictionary<string, string>();
        string url;
        if (countryCode.Equals("nn"))
            countryCode = "us"; //Change this to default country later

        if (string.IsNullOrEmpty(keyWords))
        {
            url =
                $"https://api.newscatcherapi.com/v2/latest_headlines?countries={countryCode.ToUpper()}&topic={category.ToLower()}";
        }
        else
        {
            var parsedKeywords = Uri.EscapeDataString(keyWords);
            
            url =
                $"https://api.newscatcherapi.com/v2/search?q={parsedKeywords}&countries={countryCode.ToUpper()}&topic={category.ToLower()}";
            Debug.WriteLine(url);
        }

        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("x-api-key", Keys.NewsKey());
        try
        {
            var response = client.GetStringAsync(url);
            var data = JsonNode.Parse(response.Result)!;
            var articles = data.Root["articles"]?.AsArray();
            if(articles is null)
                newsDictionary.Add("NoResults", Phrases.ErrorMessages()["NoResults"]);
            else
            {
                if (articles!.Count <= 0 || data.Root["status"]!.ToString().Equals("error"))
                {
                    newsDictionary.Add("NoResults", Phrases.ErrorMessages()["NoResults"]);
                }
                else
                {
                    //TODO: Add some randomly generated flavour.
                    RandomNumberHelper.SetIndex(articles.Count);
                    var selectedArticle = articles[RandomNumberHelper.CurrentValue];
                    if (selectedArticle != null)
                    {
                        newsDictionary.Add("Title", $"It's titled: {selectedArticle["title"]}.");
                        newsDictionary.Add("Author", $"Here's one from {selectedArticle["author"]}.");
                        newsDictionary.Add("Excerpt", $"{selectedArticle["excerpt"]}");
                        newsDictionary.Add("Summary", selectedArticle["summary"]!.ToString());
                        PersistenceHelper.SetData(PersistenceType.ArticleDate,
                            selectedArticle["published_date"]?.ToString() ?? string.Empty);
                        PersistenceHelper.SetData(PersistenceType.ArticleUrl,
                            selectedArticle["link"]?.ToString() ?? string.Empty);
                    }
                }
            }
            
        }
        catch (AggregateException e)
        {
            Debug.WriteLine(e.Message);
            newsDictionary.Add("NoResults", Phrases.ErrorMessages()["NoResults"]);
        }

        return newsDictionary;
    }

    /// <summary>
    ///     Gets a random fun fact from Ninja API.
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
            var fact = data.AsArray()[0]!["fact"];

            return fact!.ToJsonString();
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
    ///     Retrieves a random joke from joke api.
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
            Debug.Assert(joke != null, nameof(joke) + " != null");
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
            Debug.Assert(currentTemp != null, nameof(currentTemp) + " != null");
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