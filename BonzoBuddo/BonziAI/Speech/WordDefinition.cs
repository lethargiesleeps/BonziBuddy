using BonzoBuddo.Helpers;

namespace BonzoBuddo.BonziAI.Speech;

public class WordDefinition : Speech
{
    public WordDefinition(string word, bool thesaurus = false)
    {
        PhraseDictionary = ApiHelper.GetWordDefinition(word, thesaurus);
    }

    public override string GetPhrase(int index)
    {
        throw new NotSupportedException("Use GetPhrase(string key)");
    }
}