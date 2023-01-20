using BonzoBuddo.Helpers;

namespace BonzoBuddo.BonziAI.Speech;

public class WordDefinition : Speech
{
    public WordDefinition(string word, bool thesaurus = false)
    {
        PhraseDictionary = ApiHelper.GetWordDefinition(word, thesaurus);
    }

    public WordDefinition(bool definition = false, bool thesaurus = false)
    {
        var wordChosen = ApiHelper.GetRandomWord();
        if (definition)
        {
            PhraseDictionary = ApiHelper.GetWordDefinition(wordChosen, thesaurus);
        }
            
        PersistenceHelper.SetData(PersistenceType.Dictionary, wordChosen);
        
    }

    public override string GetPhrase(int index)
    {
        throw new NotSupportedException("Use GetPhrase(string key)");
    }

    
}