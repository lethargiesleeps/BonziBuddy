using System.Diagnostics;
using BonzoBuddo.BonziAI;
using BonzoBuddo.BonziAI.Speech;
using BonzoBuddo.Helpers;

namespace BonzoBuddo;

/// <summary>
///     Main class used for interaction with Bonzi.
/// </summary>
public class Bonzi
{
    private readonly FileHelper _fileHelper;
    private ISpeakable? _speechPattern;

    /// <summary>
    ///     Default constructor. Uses FileHelper to dictate if user has used program before.
    ///     <see cref="FileHelper" />
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
            Data.LastAccessed = DateTime.Now;
            _fileHelper.SaveData(Data);
        }
    }

    public bool Initialized { get; }
    public string? Temporary { get; set; }
    public bool IsHidden { get; set; }
    public BonziData? Data { get; set; }

    /// <summary>
    ///     Sets Bonzi's speech pattern which in turn dictates what he says to the user.
    /// </summary>
    /// <param name="speechPattern">Speech pattern type Bonzi needs to use.</param>
    /// <see cref="SpeechType" />
    public void SetSpeechPattern(SpeechType speechPattern)
    {
        switch (speechPattern)
        {
            case SpeechType.Greeting:
                if (Data != null)
                    _speechPattern = !Initialized
                        ? new Greeting(Phrases.BonziIntro(Temporary))
                        : new Greeting(Phrases.ReturnGreeting(Data.Name!));
                break;
            case SpeechType.Weather:
                if (_speechPattern is not WeatherForecast)
                    try
                    {
                        if (Data != null)
                            _speechPattern = new WeatherForecast(Data.City!,
                                ApiHelper.GetWeather(Data.City!, WeatherUnits.Celcius));
                    }
                    catch (HttpRequestException e)
                    {
                        Debug.WriteLine(e.Message);
                    }

                break;
            case SpeechType.Insulted:
                if (_speechPattern is not Insulted)
                    if (Data != null)
                        _speechPattern = new Insulted(Data.Name!);

                break;
            case SpeechType.Joke:
                if (_speechPattern is not Joke)
                    _speechPattern = new Joke();
                break;
            case SpeechType.Fact:
                if (_speechPattern is not Fact)
                    if (Data != null)
                        _speechPattern = new Fact(Data.Name!);
                break;
            case SpeechType.ShowHide:
                _speechPattern = new ShowHide(this);
                break;
            case SpeechType.News:
                var news = new News(PersistenceHelper.NewsKeywords, PersistenceHelper.CountryCode,
                    PersistenceHelper.NewsCategory);
                _speechPattern = news;
                break;
            case SpeechType.WordDefinition:
                _speechPattern = new WordDefinition(PersistenceHelper.Dictionary!, PersistenceHelper.Thesaurus);
                break;
            case SpeechType.RandomWord:
                _speechPattern = new WordDefinition(PersistenceHelper.Definition, PersistenceHelper.Thesaurus);
                break;
            case SpeechType.Song:
                _speechPattern = new Singing();
                break;
        }
    }


    /// <summary>
    ///     Saves this class' model data.
    ///     <see cref="FileHelper" />
    /// </summary>
    public void Save()
    {
        if (Data != null) _fileHelper.SaveData(Data);
    }

    /// <summary>
    ///     Returns Bonzi's speech using ISpeakable interface abstraction. This method gets called from the the program's
    ///     views.
    /// </summary>
    /// <returns>Implementation of ISpeakable</returns>
    /// <see cref="ISpeakable" />
    /// <seealso cref="Speech" />
    public ISpeakable? Speak()
    {
        return _speechPattern;
    }

    /// <summary>
    ///     Loads BonziData into a new BonziData instance.
    /// </summary>
    /// <returns></returns>
    public BonziData Load()
    {
        return _fileHelper.LoadData();
    }
}