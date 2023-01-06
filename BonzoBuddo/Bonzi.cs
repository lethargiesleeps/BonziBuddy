using System.Diagnostics;
using System.Runtime.CompilerServices;
using BonzoBuddo.BonziAI;
using BonzoBuddo.BonziAI.Speech;
using BonzoBuddo.Helpers;

namespace BonzoBuddo;

public class Bonzi
{
    public bool Initialized { get; }
    public string Temporary { get; set; }
    public BonziData? Data { get; set; }
    private FileHelper _fileHelper;
    private ISpeakable _speechPattern;
    

    public Bonzi()
    {
        _fileHelper = new FileHelper();
        Data = new BonziData();
        if (_fileHelper.CheckFolder() && _fileHelper.CheckDataFile())
        {
            Initialized = true;

        }
        else
        {
            Initialized = false;
            _fileHelper.CreateDirectory();
        }

        if (Initialized)
        {
            Data = _fileHelper.LoadData();
            Debug.WriteLine(Data.Name);
            Debug.WriteLine(Data.City);
        }

    }

    public void SetSpeechPattern(SpeechType speechPattern)
    {
        switch (speechPattern)
        {
            case SpeechType.Greeting:
                if(_speechPattern is not Greeting)
                    _speechPattern = !Initialized ? new Greeting(Phrases.BonziIntro(Temporary)) 
                        : new Greeting(Phrases.ReturnGreeting(Data.Name));
                break;
            case SpeechType.Weather:
                if (_speechPattern is not WeatherForecast)
                {
                    try
                    {
                        _speechPattern = new WeatherForecast(Data.City,
                            ApiHelper.GetWeather(Data.City, WeatherUnits.Celcius));
                    }
                    catch (HttpRequestException e)
                    {
                        Debug.WriteLine(e.Message);
                    }
                }

                break;
            case SpeechType.Insulted:
                if (_speechPattern is not Insulted)
                    _speechPattern = new Insulted(Data.Name);

                break;
        }
    }
    public void Save()
    {
        if (Data != null) _fileHelper.SaveData(Data);
    }
    
    public ISpeakable Speak() => _speechPattern;
    public BonziData Load() => _fileHelper.LoadData();
    



}