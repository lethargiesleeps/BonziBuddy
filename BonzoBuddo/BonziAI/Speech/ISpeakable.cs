namespace BonzoBuddo.BonziAI.Speech;

/// <summary>
///     Interface used for Bonzi's responses. Implemented by Speech and it's derivatives.
///     <see cref="Speech" />
/// </summary>
public interface ISpeakable
{
    public string GetRandomPhrase();
    public string GetPhrase(string key);
    public string GetPhrase(int index);
    public string GetPhrase();
    public List<string> GetPhraseList();
    public Dictionary<string, string> GetPhraseDictionary();
}