namespace BonzoBuddo.BonziAI.Speech;

/// <summary>
///     Speech pattern used when user insults Bonzi
/// </summary>
public class Insulted : Speech
{
    private readonly string _name;

    /// <summary>
    ///     Default constructor
    /// </summary>
    /// <param name="name">The user's name.</param>
    public Insulted(string name)
    {
        _name = name;
        PhraseList = Phrases.Insulted(_name);
    }
}