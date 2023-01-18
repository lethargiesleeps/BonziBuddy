namespace BonzoBuddo.BonziAI.Speech;

/// <summary>
///     Speech Bonzi uses when retrieving the forecast. This class uses the phrase dictionary instead of phrase list.
/// </summary>
public class WeatherForecast : Speech
{
    private readonly string? _city;
    private readonly float _currentTemp;

    /// <summary>
    ///     Default constructor.
    /// </summary>
    /// <param name="city">User's city.</param>
    /// <param name="currentTemp">Temperature retrieved using OpenWeather API and ApiHelper class</param>
    public WeatherForecast(string city, float currentTemp)
    {
        _city = city;
        _currentTemp = currentTemp;
        PhraseDictionary = Phrases.WeatherForecasts(_city, _currentTemp);
    }

    /// <summary>
    ///     Method unsupported by implementation.
    /// </summary>
    /// <param name="key">Not used</param>
    /// <returns>See exception.</returns>
    /// <exception cref="NotSupportedException">Throws if this method is used with this child class.</exception>
    public override string GetPhrase(string key)
    {
        throw new NotSupportedException("Please us GetPhrase() with no parameters for method call of this object");
    }

    /// <summary>
    ///     Method unsupported by implementation.
    /// </summary>
    /// <param name="index">Not used.</param>
    /// <returns>See exception</returns>
    /// <exception cref="NotSupportedException"></exception>
    public override string GetPhrase(int index)
    {
        throw new NotSupportedException("Please us GetPhrase() with no parameters for method call of this object");
    }

    /// <summary>
    ///     Changes the phrase Bonzi says depending on the temperature received from API.
    /// </summary>
    /// <returns></returns>
    public override string GetPhrase()
    {
        switch (_currentTemp)
        {
            case > -50.0f and <= -25.0f:
                return PhraseDictionary["VeryCold"];
            case > -25.0f and <= 0.0f:
                return PhraseDictionary["Cold"];
            case > 0.0f and <= 15.0f:
                return PhraseDictionary["Brisk"];
            case > 15.0f and <= 30.0f:
                return PhraseDictionary["Hot"];
            case > 30.0f and <= 40.0f:
                return PhraseDictionary["VeryHot"];

            default:
                return Phrases.ErrorMessages()["NoWeather"];
        }
    }
}