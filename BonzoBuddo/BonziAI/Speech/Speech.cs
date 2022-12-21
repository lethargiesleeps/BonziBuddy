using BonzoBuddo.BonziAI.Interfaces;
using BonzoBuddo.BonziAI.Tools;

namespace BonzoBuddo.BonziAI.Speech;

public class Speech : ISpeakable
{
    protected List<string> Phrases;
    protected IRandomizable Rng;
    protected bool[] PhrasesSpoken;
    protected string EnumeratedPhrase;

    public Speech()
    {
        Rng = new RandomListIterator();

    }

    public virtual string GetPhrase()
    {
        Rng.SetCurrentValue();
        Rng.SetPreviousValue();
        Rng.SetUpperBound(Phrases.Count);
        if (PhrasesSpoken.All(s => s))
            return AllEnumerated();

        if (PhrasesSpoken[Rng.GetCurrentValue()])
        {
            Rng.SetCurrentValue();
            Rng.SetPreviousValue();
            PhrasesSpoken[Rng.GetCurrentValue()] = true;
            return Phrases[Rng.GetCurrentValue()];
        }

        PhrasesSpoken[Rng.GetCurrentValue()] = true;
        return Phrases[Rng.GetCurrentValue()];
    }

    public List<string> GetPhrases()
    {
        return Phrases;
    }

    public string AllEnumerated()
    {
        return EnumeratedPhrase;
    }
}