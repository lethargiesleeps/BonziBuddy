namespace BonzoBuddo.BonziAI.Speech;

public class Singing : Speech
{
    private Songs.Songs _songs;
    public Singing()
    {
        _songs = new Songs.Songs();
        PhraseList = _songs.SongData();
    }

    public override string GetRandomPhrase() =>  _songs.GetRandomSong();
    public override string GetPhrase(int index) => PhraseList![index];

    public override Dictionary<string, string> GetPhraseDictionary() =>
        throw new NotSupportedException("This instance does not contain a dictionary");
    public override string GetPhrase(string key) => _songs.GetSongByTitle(key);
}