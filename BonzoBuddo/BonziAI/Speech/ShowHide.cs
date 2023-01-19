namespace BonzoBuddo.BonziAI.Speech;

public class ShowHide : Speech
{
    public ShowHide(Bonzi bonzi)
    {
        if (bonzi.Data != null)
            PhraseList = !bonzi.IsHidden
                ? Phrases.ShowMessages(bonzi.Data.Name!)
                : Phrases.HideMessages(bonzi.Data.Name!);
    }

    public override string GetPhrase(string key)
    {
        throw new NotSupportedException(
            "This implementation does not have a Phrase Dictionary, use Phrase List instead.");
    }
}