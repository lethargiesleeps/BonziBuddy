namespace BonzoBuddo.BonziAI.Speech;

public class Weather : Speech
{
    private float _currentTemp;
    private string? _city;


    public Weather(float currentTemp, string? city = null) : this()
    {
        _currentTemp = currentTemp;
        _city = city;
        Phrases = Tools.Phrases.GetForecasts(_currentTemp, _city);
    }

    public Weather()
    {

        EnumeratedPhrase = "I don't want to give you the weather right now.";
    }

    public override string GetPhrase()
    {
        switch (_currentTemp)
        {
            case <= -20.0f:
                return Phrases[0];
            case <= 0.0f and > -20.0f:
                return Phrases[1];
            case > 0.0f and <= 25.0f:
                return Phrases[2];
            case > 25.0f and <= 40.0f:
                return Phrases[3];
            case > 40.0f:
                return Phrases[4];
            default:
                return Phrases[5];
        }
    }

    public void SetWeather(float weather) => _currentTemp = weather;
    public void SetCity(string city) => _city = city;
}