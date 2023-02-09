namespace BonzoBuddo.BonziAI.Speech;

/// <summary>
/// Speech pattern for Bonzi songs
/// </summary>
public class Singing : Speech
{
    private readonly Songs.Songs _songs;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public Singing()
    {
        _songs = new Songs.Songs();
        PhraseList = _songs.SongData();
    }

    /// <summary>
    /// Returns a random song.
    /// </summary>
    /// <returns>Returns a random song from song list.</returns>
    public override string GetRandomPhrase() => _songs.GetRandomSong();

    /// <summary>
    /// Returns a song at specified index.
    /// </summary>
    /// <param name="index">Index of song from song list.</param>
    /// <returns>Song data as string.</returns>
    public override string GetPhrase(int index) => PhraseList![index];

    /// <summary>
    /// Method unsupported by implementation.
    /// </summary>
    /// <returns>See exception.</returns>
    /// <exception cref="NotSupportedException">Throws if this method is used with this child class.</exception>
    public override Dictionary<string, string> GetPhraseDictionary() => throw new NotSupportedException("This instance does not contain a dictionary");

    /// <summary>
    /// Searches for song by searching song dictionary.
    /// WARNING: Might crash if invalid song title.
    /// </summary>
    /// <param name="key">Name of songs.</param>
    /// <returns>Song data as string.</returns>
    public override string GetPhrase(string key) => _songs.GetSongByTitle(key);
}