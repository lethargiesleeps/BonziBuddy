namespace BonzoBuddo.BonziAI.Interfaces;

public interface ISpeakable
{
    public string GetPhrase();
    public List<string> GetPhrases();
    public string AllEnumerated();
}