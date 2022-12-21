namespace BonzoBuddo.BonziAI.Speech;

public class Joke : Speech
{
    public Joke()
    {
        Phrases = Tools.Phrases.GetJokes();
        PhrasesSpoken = new bool[Phrases.Count];
        EnumeratedPhrase = "Sorry buddy, I am out of jokes.";
    }

    
}