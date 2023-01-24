using System.Text;
using BonzoBuddo.BonziAI.Songs.SongBuilder;
using BonzoBuddo.Helpers;

namespace BonzoBuddo.BonziAI.Songs;

/// <summary>
///     This class contains a Dictionary with all available songs for Bonzi to sing.
///     Songs should be created in this class with their own respective static methods.
///     ex: private static Song TwinkleTwinkleLittleStar().
/// </summary>
public class Songs
{
    private List<Song>? _songList;

    /// <summary>
    ///     Static constructor. Loads the songs that can be accessed.
    /// </summary>
    public Songs()
    {
        LoadSongs();
    }

    public List<string> SongData()
    {
        return _songList!.Select(s => s.ToString()).ToList();
    }

    /// <summary>
    ///     Searches for song with matching title and returns it's string data.
    /// </summary>
    /// <param name="title">Title of the song.</param>
    /// <returns>Data of song as string for Bonzi to sing</returns>
    /// <exception cref="KeyNotFoundException">Throws if song cannot be found.</exception>
    public string GetSongByTitle(string title)
    {
        foreach (var song in _songList!.Where(song => CleanTitle(song.Title).Equals(CleanTitle(title))))
            return song.ToString();

        throw new KeyNotFoundException("Could not find song with name: " + title);
    }

    /// <summary>
    ///     Gets a random song an returns it's string data.
    /// </summary>
    /// <returns>Data of song as string for Bonzi to sing.</returns>
    public string GetRandomSong()
    {
        RandomNumberHelper.SetIndex(_songList);
        var song = _songList![RandomNumberHelper.CurrentValue];
        return song.ToString();
    }

    /// <summary>
    ///     Adds a song to the SongDictionary.
    /// </summary>
    private void LoadSongs()
    {
        _songList = new List<Song>
        {
            TwinkleTwinkle(),
            MaryHadALittleLamb(),
            WokeUpLikeThis(),
            AllStar()
        };
    }

    /// <summary>
    ///     Removes white space and converts to lowercase.
    /// </summary>
    /// <param name="title">String to clean.</param>
    /// <returns>Formatted string.</returns>
    private static string CleanTitle(string title)
    {
        title = title.ToLower();
        var sb = new StringBuilder();
        foreach (var c in title.Where(c => !c.Equals(' ')))
            sb.Append(c);
        return sb.ToString();
    }

    private static Song AllStar()
    {
        Notes.ResetNotes();
        var speed = 100;
        var lowerG = Notes.G.DecreaseOctave();
        var lowerE = Notes.E.DecreaseOctave();
        var song = new Song("All-Star").SetInitialSpeed(500).AddNote(lowerG, "Some").AddSpeed(speed)
            .AddNote(Notes.D, "bah").AddNote(Notes.B, "dee").SubtractSpeed(speed).AddNote(Notes.B, "once")
            .AddSpeed(speed).AddNote(Notes.A, "told").AddNote(lowerG, "me").AddNote(lowerG, "the")
            .SubtractSpeed(speed).AddNote(Notes.C, "world").AddSpeed(speed).AddNote(Notes.B, "is")
            .AddNote(Notes.B, "gun")
            .AddNote(Notes.A, "nah").AddNote(lowerG, "roll").AddNote(lowerG, "me");

        song.AddNote(lowerG, $"{PersistenceHelper.Name}").AddNote(Notes.D, "ain't").AddNote(Notes.B, "the")
            .AddNote(Notes.B, "shar").AddNote(Notes.A, "pest").AddNote(Notes.A, "tool")
            .AddNote(lowerG, "in").AddNote(lowerG, "the").SubtractSpeed(speed).AddPause(500).AddNote(lowerE, "shed.");

        return song;
    }

    private static Song WokeUpLikeThis()
    {
        Notes.ResetNotes();
        var dSharp = Notes.DSharp;
        var g = Notes.G.DecreaseOctave();
        var gSharp = Notes.GSharp;
        var f = Notes.F.DecreaseOctave();

        var song = new Song("Woke Up Like This").SetInitialSpeed(350).AddNote(dSharp, "Doo")
            .AddNote(g, "doo").SubtractSpeed(50)
            .AddNote(gSharp, "doo").SubtractSpeed(50).AddNote(Notes.F, "doooo,").AddPause(500).ResetSpeed();

        song.AddNote(dSharp, "Doo")
            .AddNote(g, "doo").SubtractSpeed(50)
            .AddNote(gSharp, "doo").SubtractSpeed(50).AddNote(Notes.F, "doooo.").AddPause(500).ResetSpeed()
            .ChangeSpeed(300);

        song.AddSpeed(100).AddNote(dSharp, "Woke").AddNote(dSharp, "up").AddNote(dSharp, "to").AddPause(500)
            .AddNote(g, $"{PersistenceHelper.Name}").AddNote(g, "sounding").SubtractSpeed(100)
            .AddNote(gSharp, "like").AddNote(f, "me.").AddPause(500).ResetSpeed();

        song.AddSpeed(100).AddNote(dSharp, "Woke").AddNote(dSharp, "up").AddNote(dSharp, "to").AddPause(500)
            .AddNote(g, $"{PersistenceHelper.Name}").AddNote(g, "talking").SubtractSpeed(100)
            .AddNote(gSharp, "like").AddNote(f, "me.").AddPause(500).ResetSpeed();


        return song;
    }

    private static Song TwinkleTwinkle()
    {
        Notes.ResetNotes();
        var song = new Song("Twinkle Twinkle Little Bonzi").SetInitialSpeed(250).AddNote(Notes.C, "Twin")
            .AddNote(Notes.C, "kle")
            .AddNote(Notes.G, "twin").AddNote(Notes.G, "kle").ChangeSpeed(100)
            .AddNote(Notes.A.IncreaseOctave(), "little")
            .ResetNotes().AddPause(50).SubtractSpeed(50).AddNote(Notes.G, "Bonzi.").AddPause(500)
            .ChangeSpeed(250);

        song.AddNote(Notes.F, "How").AddNote(Notes.F, "I").AddNote(Notes.E, "won").AddNote(Notes.E, "der")
            .AddNote(Notes.D, "why").AddNote(Notes.D, "you're").SubtractSpeed(50).AddPause(500)
            .AddNote(Notes.C, $"{PersistenceHelper.Name}!");
        return song;
    }

    /// <summary>
    ///     Song object for the song 'Mary had a little lamb'.
    /// </summary>
    /// <returns>Song to be converted into song data.</returns>
    private static Song MaryHadALittleLamb()
    {
        Notes.ResetNotes();
        return new Song($"Bonzi Had A Little {PersistenceHelper.Name}").SetInitialSpeed(120).AddNote(Notes.E, "Bonzi")
            .AddNote(Notes.D, "had").AddNote(Notes.C, "a").AddNote(Notes.D, "little")
            .AddNote(Notes.E, $"{PersistenceHelper.Name}.")
            .AddPause(300).AddNote(Notes.D, "Little").AddNote(Notes.D, $"{PersistenceHelper.Name}.").AddPause(300)
            .AddNote(Notes.E, "Little").AddNote(Notes.G, $"{PersistenceHelper.Name}!")
            .AddNote(Notes.E, "Bonzi").AddNote(Notes.D, "had").AddNote(Notes.C, "a")
            .AddNote(Notes.D, "little").AddNote(Notes.E, $"{PersistenceHelper.Name},")
            .AddNote(Notes.E, "their").AddNote(Notes.E, "wool").AddNote(Notes.D, "was")
            .AddNote(Notes.E, "white").AddNote(Notes.D, "as").SubtractSpeed(50).AddNote(Notes.C, "snow!");
    }
}