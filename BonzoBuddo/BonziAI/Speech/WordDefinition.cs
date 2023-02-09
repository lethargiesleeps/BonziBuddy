using BonzoBuddo.Helpers;

namespace BonzoBuddo.BonziAI.Speech;

/// <summary>
/// Speech pattern for Dictionary functionality.
/// </summary>
public class WordDefinition : Speech
{
    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="word">Word being searched</param>
    /// <param name="thesaurus">Whether or not to implement Thesaurus functionality.</param>
    public WordDefinition(string word, bool thesaurus = false)
    {
        PhraseDictionary = ApiHelper.GetWordDefinition(word, thesaurus);
    }

    /// <summary>
    /// Constructor used for Random Word functionality.
    /// </summary>
    /// <param name="definition">Whether to get the definition. If true, will perform 2nd API call to retrieve.</param>
    /// <param name="thesaurus">Whether or not to implement Thesaurus functionality.</param>
    public WordDefinition(bool definition = false, bool thesaurus = false)
    {
        var wordChosen = ApiHelper.GetRandomWord();
        if (definition) PhraseDictionary = ApiHelper.GetWordDefinition(wordChosen, thesaurus);

        PersistenceHelper.SetData(PersistenceType.Dictionary, wordChosen);
    }

    /// <summary>
    /// Method unsupported by implementation.
    /// </summary>
    /// <param name="index">Not used.</param>
    /// <returns>See exception.</returns>
    /// <exception cref="NotSupportedException">Throws if this method is used with this child class.</exception>
    public override string GetPhrase(int index) => throw new NotSupportedException("Use GetPhrase(string key)");
}