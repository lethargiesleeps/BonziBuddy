using BonzoBuddo.Helpers;

namespace BonzoBuddo.BonziAI.Speech;

/// <summary>
///     Speech pattern used for jokes.
/// </summary>
public class Joke : Speech
{
    /// <summary>
    ///     Default constructor for Joke.
    /// </summary>
    public Joke()
    {
        PhraseDictionary = Phrases.JokeExtras();
    }

    /// <summary>
    ///     Gets a random jok, using ApiHelper class and Ninja APIs
    /// </summary>
    /// <returns>Returns random joke using ApiHelper</returns>
    public override string GetPhrase()
    {
        return ApiHelper.GetJoke();
    }


    /// <summary>
    ///     Method unsupported by implementation.
    /// </summary>
    /// <param name="index">Not used.</param>
    /// <returns>See exception</returns>
    /// <exception cref="NotSupportedException">Throws if this method is used with this child class.</exception>
    public override string GetPhrase(int index) => throw new NotSupportedException("Use parameter-less GetPhrase() or GetPhrase(string key)");
}