using BonzoBuddo.Helpers;

namespace BonzoBuddo.BonziAI.Speech;

/// <summary>
/// Speech pattern used for jokes.
/// </summary>
public class Joke : Speech
{
    public override string GetPhrase() => ApiHelper.GetJoke();
    public override string GetPhrase(int index)
    {
        throw new NotImplementedException("Use GetPhrase()");
    }

    public override string GetPhrase(string key)
    {
        throw new NotImplementedException("Use GetPhrase()");
    }
}