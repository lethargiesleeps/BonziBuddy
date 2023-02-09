namespace BonzoBuddo.BonziAI.Speech;

public class Singing : Speech
{
    private readonly Songs.Songs _songs;

    public Singing()
    {
        _songs = new Songs.Songs();
        PhraseList = _songs.SongData();
    }

    public override string GetRandomPhrase()
    {
        return _songs.GetRandomSong();
    }

    public override string GetPhrase(int index)
    {
        return PhraseList![index];
    }

    public override Dictionary<string, string> GetPhraseDictionary()
    {
        throw new NotSupportedException("This instance does not contain a dictionary");
    }

    public override string GetPhrase(string key)
    {
        return _songs.GetSongByTitle(key);
    }
}