using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using BonzoBuddo.BonziAI.Interfaces;
using BonzoBuddo.BonziAI.Speech;
using BonzoBuddo.BonziAI.Tools;
using DoubleAgent.Control;

namespace BonzoBuddo.BonziAI;

public class Bonzi
{
    private ISpeakable _speech;
    private string _path;
    private string _dataPath;
    private bool _hasBeenInitialized = false;
    private BonziData? _data;
    private FileStream _stream;
    private string _jsonData;

    public Bonzi()
    {
        Init();
    }

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
        if (string.IsNullOrEmpty(cityText) || string.IsNullOrWhiteSpace(cityText))
            return Phrases.GetErrors()["NoCity"];

        try
        {
            var bytes = Encoding.UTF8.GetBytes(cityText);
            cityText = Encoding.UTF8.GetString(bytes);
            var client = new HttpClient();
            var response = client.GetStringAsync(
                $"https://api.openweathermap.org/data/2.5/weather?q={cityText}&appid=79002f649b41ab93f1bc47f86efc5fff&units=metric");

            var data = JsonNode.Parse(response.Result)!;
            var currentTemp = data.Root["main"]?["temp"];
            var city = data.Root["name"];
            var weather = new Weather(float.Parse(currentTemp.ToString()), city.ToString());
            _speech = weather;
            var returnValue = (Weather) _speech;
            _data.City = cityText;
            
            
            return returnValue.GetPhrase();
        }
        catch
        {
            return "I could not connect to the internet to fulfill my duty of obtaining your information...\n" +
                   "Oops, I meant that I just don't feel like giving you the weather right now.";
        }
    }

    public void SerializeAndWrite()
    {
        StreamReader reader = new StreamReader(_dataPath);
        StreamWriter writer = new StreamWriter(_dataPath);
        writer.Write(JsonSerializer.Serialize(_data));
        writer.Close();
        
    }

    //TODO: Manage files better, Write to json at intervals
    private void Init()
    {
        _data = new BonziData();
        _path = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\BonziBuddy\\";
        _dataPath = _path + "\\Data\\data.txt";
        
        if (!Directory.Exists(_path))
        {
            Directory.CreateDirectory(_path);
            Directory.CreateDirectory(_path + "Data");
            _data.Name = "Unknown";
            _data.BonziScore = 0.0f;
            _data.LastAccessed = DateTime.Now;
            
            StreamWriter file = new StreamWriter(_dataPath);
            
            _jsonData = JsonSerializer.Serialize(_data);
            
            file.Write(_jsonData);
            file.Close();

        }
        else
        {
            _hasBeenInitialized = true;
            StreamReader file = new StreamReader(_dataPath);
            _jsonData = file.ReadToEnd();
            _data = JsonSerializer.Deserialize<BonziData>(_jsonData);
            file.Close();
            Dev.Log(_jsonData);

        }
            


    }

    public void PlayBadJoke(DialogResult result, Character bonzi)
    {
        if (result == DialogResult.OK || result == DialogResult.No)
        {
            bonzi.Speak(Phrases.BadJoke());
            bonzi.Play("Giggle");
        }
    }
    //TODO: Decouple into a Speech pattern
    public List<string> Greet()
    {
        if (!_hasBeenInitialized)
        {
            return Phrases.FirstTimeGreeting();
        }

        else
        {
            TimeSpan ts = DateTime.Now - _data.LastAccessed;
            if (ts.Days > 10)
                return new List<string>()
                {
                    "Well well, it's been a long time. I missed you so much."
                };
            else
                return Phrases.ReturnGreetings(_data.Name);
        }
            

    }

    public bool GetInitializationStatus()
    {
        return _hasBeenInitialized;
    }

    public BonziData GetBonziData() => _data;


}