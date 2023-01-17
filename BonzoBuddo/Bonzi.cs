using System.Diagnostics;
using System.Runtime.CompilerServices;
using BonzoBuddo.BonziAI;
using BonzoBuddo.BonziAI.Speech;
using BonzoBuddo.Helpers;

namespace BonzoBuddo;

/// <summary>
/// Main class used for interaction with Bonzi.
/// </summary>
public class Bonzi
{
    public bool Initialized { get; }
    public string Temporary { get; set; }
    public bool IsHidden { get; set; }
    public BonziData? Data { get; set; }
    private FileHelper _fileHelper;
    private ISpeakable _speechPattern;
    
    /// <summary>
    /// Default constructor. Uses FileHelper to dictate if user has used program before.
    /// <see cref="FileHelper"/>
    /// </summary>
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

    /// <summary>
    /// Sets Bonzi's speech pattern which in turn dictates what he says to the user.
    /// </summary>
    /// <param name="speechPattern">Speech pattern type Bonzi needs to use.</param>
    /// <see cref="SpeechType"/>
    public void SetSpeechPattern(SpeechType speechPattern)
    {
        switch (speechPattern)
        {
            case SpeechType.Greeting:
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
            case SpeechType.Joke:
                if (_speechPattern is not Joke)
                    _speechPattern = new Joke();
                break;
        }
    }

    /// <summary>
    /// Saves this class' model data.
    /// <see cref="FileHelper"/>
    /// </summary>
    public void Save()
    {
        if (Data != null) _fileHelper.SaveData(Data);
    }
    
    /// <summary>
    /// Returns Bonzi's speech using ISpeakable interface abstraction. This method gets called from the the program's views.
    /// </summary>
    /// <returns>Implementation of ISpeakable</returns>
    /// <see cref="ISpeakable"/>
    /// <seealso cref="Speech"/>
    public ISpeakable Speak() => _speechPattern;

    /// <summary>
    /// Loads BonziData into a new BonziData instance.
    /// </summary>
    /// <returns></returns>
    public BonziData Load() => _fileHelper.LoadData();
    



}