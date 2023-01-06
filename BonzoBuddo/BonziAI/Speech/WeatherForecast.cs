namespace BonzoBuddo.BonziAI.Speech;

public class WeatherForecast : Speech
{
    private float _currentTemp;
    private string? _city;

    public WeatherForecast (string city, float currentTemp)
    {
        _city = city;
        _currentTemp = currentTemp;
        PhraseDictionary = Phrases.WeatherForecasts(_city, _currentTemp);
    }

    public override string GetPhrase(string key)
    {
        throw new NotSupportedException("Please us GetPhrase() with no parameters for method call of this object");
    }

    public override string GetPhrase(int index)
    {
        throw new NotSupportedException("Please us GetPhrase() with no parameters for method call of this object");
    }

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

            default:
                return "Hmm something went wrong.";
        }
    }

}