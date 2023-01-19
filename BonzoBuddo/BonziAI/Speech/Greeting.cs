namespace BonzoBuddo.BonziAI.Speech;

/// <summary>
///     Speech Bonzi uses when greeting the user, whether on first time use or returning usage.
/// </summary>
public class Greeting : Speech
{
    /// <summary>
    ///     Used if Bonzi is loaded and all needed files are created.
    /// </summary>
    /// <see cref="Bonzi" />
    /// <param name="phrases">Greeting phrases from Phrases static class</param>
    public Greeting(List<string>? phrases) : base(phrases)
    {
    }

    /// <summary>
    ///     Used only for first time greeting.
    /// </summary>
    /// <see cref="Bonzi" />
    /// <param name="phrases">Override phrases if needed.</param>
    public Greeting(Dictionary<string, string>? phrases) : base(phrases)
    {
        PhraseList = Phrases.FirstTimeGreeting();
    }
}