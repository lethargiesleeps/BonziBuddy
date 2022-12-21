using System.Diagnostics;
using System.Text;
using System.Text.Json.Nodes;
using BonzoBuddo.BonziAI.Interfaces;
using BonzoBuddo.BonziAI.Speech;

namespace BonzoBuddo.BonziAI;

public class Bonzi
{
    private ISpeakable _speech;


    public void SetSpeechPattern(SpeechType speech)
    {
        switch (speech)
        {
            case SpeechType.Joke:
                if (_speech is not Joke)
                    _speech = new Joke();
                break;
            case SpeechType.Weather:
                if (_speech is not Weather)
                    _speech = new Weather();
                break;
        }
    }

    public string GetPhrase()
    {
        return _speech.GetPhrase();
    }

    public string GetCurrentWeather(string cityText)
    {
        try
        {
            var bytes = Encoding.UTF8.GetBytes(cityText);
            cityText = Encoding.UTF8.GetString(bytes);
            Debug.WriteLine(cityText);
            var client = new HttpClient();
            var response = client.GetStringAsync(
                $"https://api.openweathermap.org/data/2.5/weather?q={cityText}&appid=79002f649b41ab93f1bc47f86efc5fff&units=metric");

            
            var data = JsonNode.Parse(response.Result)!;
            var currentTemp = data.Root["main"]?["temp"];
            var city = data.Root["name"];
            var weather = new Weather(float.Parse(currentTemp.ToString()), city.ToString());
            _speech = weather;
            var returnValue = (Weather) _speech;
            return returnValue.GetPhrase();
        }
        catch
        {
            return "I could not connect to the internet to fulfill my duty of obtaining your information...\n" +
                   "Oops, I meant that I just don't feel like giving you the weather right now.";
        }
    }
}