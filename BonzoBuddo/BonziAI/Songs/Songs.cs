using BonzoBuddo.BonziAI.Songs.SongBuilder;

namespace BonzoBuddo.BonziAI.Songs;

/// <summary>
/// This class contains a Dictionary with all available songs for Bonzi to sing.
/// Songs should be created in this class with their own respective static methods.
/// ex: private static Song TwinkleTwinkleLittleStar().
/// </summary>
public class Songs
{
    public Dictionary<string, Song> SongDictionary { get; private set; }

    /// <summary>
    /// Static constructor. Loads the songs that can be accessed.
    /// </summary>
    public Songs()
    {
        SongDictionary = new Dictionary<string, Song>();
        LoadSongs();
    }

    /// <summary>
    /// Adds a song to the SongDictionary.
    /// </summary>
    private void LoadSongs()
    {
        SongDictionary.Add(MaryHadALittleLamb().Title, MaryHadALittleLamb());
    }

    /// <summary>
    /// Song object for the song 'Mary had a little lamb'.
    /// </summary>
    /// <returns>Song to be converted into song data.</returns>
    private Song MaryHadALittleLamb()
    {
        return new Song("Mary Had A Little Lamb").SetInitialSpeed(120).AddNote(Notes.E, "Mary")
            .AddNote(Notes.D, "had").AddNote(Notes.C, "a").AddNote(Notes.D, "little").AddNote(Notes.E, "lamb.")
            .AddPause(300).AddNote(Notes.D, "Little").AddNote(Notes.D, "lamb.").AddPause(300)
            .AddNote(Notes.E, "Little").AddNote(Notes.G, "lamb!")
            .AddNote(Notes.E, "Mary").AddNote(Notes.D, "had").AddNote(Notes.C, "a")
            .AddNote(Notes.D, "little").AddNote(Notes.E, "lamb,")
            .AddNote(Notes.E, "it's").AddNote(Notes.E, "wool").AddNote(Notes.D, "was")
            .AddNote(Notes.E, "white").AddNote(Notes.D, "as").SubtractSpeed(50).AddNote(Notes.C, "snow!");
    }

}