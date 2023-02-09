namespace BonzoBuddo.BonziAI.Speech;

/// <summary>
/// Speech pattern for when Bonzi gets hidden or shown.
/// </summary>
public class ShowHide : Speech
{
    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="bonzi">Bonzi object to evaluate</param>
    public ShowHide(Bonzi bonzi)
    {
        if (bonzi.Data != null)
            PhraseList = !bonzi.IsHidden
                ? Phrases.ShowMessages(bonzi.Data.Name!)
                : Phrases.HideMessages(bonzi.Data.Name!);
    }

    /// <summary>
    /// Method unsupported by implementation.
    /// </summary>
    /// <param name="key">Not used.</param>
    /// <returns>See exception.</returns>
    /// <exception cref="NotSupportedException">Throws if this method is used with this child class.</exception>
    public override string GetPhrase(string key) =>
        throw new NotSupportedException(
            "This implementation does not have a Phrase Dictionary, use Phrase List instead.");

    /// <summary>
    /// Method unsupported by implementation.
    /// </summary>
    /// <returns>See exception.</returns>
    /// <exception cref="NotSupportedException">Throws if this method is used with this child class.</exception>
    public override Dictionary<string, string>? GetPhraseDictionary() =>
        throw new NotSupportedException(
            "This implementation does not have a Phrase Dictionary, use Phrase List instead.");
}