namespace BonzoBuddo.BonziAI.Speech;

/// <summary>
///     Speech pattern used when user insults Bonzi
/// </summary>
public class Insulted : Speech
{
    /// <summary>
    ///     Default constructor
    /// </summary>
    /// <param name="name">The user's name.</param>
    public Insulted(string name)
    {
        PhraseList = Phrases.Insulted(name);
    }
}