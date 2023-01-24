using System.Text;
using BonzoBuddo.Helpers;

namespace BonzoBuddo.BonziAI.Songs.SongBuilder;

/// <summary>
///     Class used to construct songs for Bonzi to sing.
///     Song is returned as a string by calling ToString() on it, and most methods return the current Song object.
/// </summary>
public class Song
{
    /// <summary>
    ///     Default constructor.
    /// </summary>
    /// <param name="title">Title of the song with spaces, used to retrieve from SongsDictionary</param>
    public Song(string title)
    {
        SongString = new StringBuilder();
        Notes = new List<Note>();
        Title = title;
        SongString.Append("\\Chr=\"Monotone\"\\");
    }

    public List<Note> Notes { get; }
    public string Title { get; }
    public StringBuilder SongString { get; }
    public int Speed { get; private set; }
    public int InitialSpeed { get; private set; }

    /// <summary>
    ///     Increases speed of note, prefix before adding note you want to adjust.
    /// </summary>
    /// <param name="value">Value to be added to speed.</param>
    /// <returns>The current song object.</returns>
    public Song AddSpeed(int value)
    {
        Speed += value;
        if (Speed > 0) SongString.Append($"\\Spd={Speed}\\");
        return this;
    }

    /// <summary>
    ///     Resets all notes that have been adjusted.
    /// </summary>
    /// <returns>The current song object.</returns>
    public Song ResetNotes()
    {
        SongBuilder.Notes.ResetNotes();
        return this;
    }

    /// <summary>
    ///     Decreases speed of note, prefix before adding note you want to adjust.
    /// </summary>
    /// <param name="value">Value to be removed from speed.</param>
    /// <returns>The current song object.</returns>
    public Song SubtractSpeed(int value)
    {
        Speed -= value;
        if (Speed > 0) SongString.Append($"\\Spd={Speed}\\");
        return this;
    }

    /// <summary>
    ///     Changes speed value directly.
    /// </summary>
    /// <param name="value">Value of speed.</param>
    /// <returns>The current song object.</returns>
    public Song ChangeSpeed(int value)
    {
        Speed = value;
        SongString.Append($"\\Spd={Speed}\\");
        return this;
    }

    /// <summary>
    ///     Resets speed of song to initial speed value.
    /// </summary>
    /// <returns>The current song object.</returns>
    public Song ResetSpeed()
    {
        Speed = InitialSpeed;
        SongString.Append($"\\Spd={Speed}\\");
        return this;
    }

    /// <summary>
    ///     Adds a Note to the song.
    /// </summary>
    /// <param name="note">The note to be added.</param>
    /// <param name="syllable">The word Bonzi speaks at selected Note's pitch.</param>
    /// <see cref="Note" />
    /// <returns>The current song object.</returns>
    public Song AddNote(Note note, string syllable)
    {
        note.SetSyllable(syllable);
        Notes.Add(note);
        SongString.Append(note.ToString());
        return this;
    }

    /// <summary>
    ///     Adds a pause to the song in milliseconds.
    /// </summary>
    /// <param name="milliseconds">The time interval of the pause.</param>
    /// <returns>The current song object.</returns>
    public Song AddPause(int milliseconds)
    {
        if (milliseconds < 100)
            milliseconds = 100;
        SongString.Append($"\\Pau={milliseconds}\\");
        return this;
    }

    /// <summary>
    ///     Sets the initial speed value of the song. Should be the first method used when creating a song.
    ///     The initial speed value does not change when modifying speed value, using ResetSpeed will change the speed back
    ///     it's
    ///     original value.
    /// </summary>
    /// <param name="speed">Value of initial song speed.</param>
    /// <returns>The current song object.</returns>
    public Song SetInitialSpeed(int speed)
    {
        InitialSpeed = speed;
        Speed = speed;
        if (Speed > 0) SongString.Append($"\\Spd={Speed}\\");
        return this;
    }

    /// <summary>
    ///     Returns the song to be used in TTS engine.
    /// </summary>
    /// <returns>A string containing all the song data.</returns>
    public override string ToString()
    {
        //SongString.Append("\"");
        PersistenceHelper.SetData(PersistenceType.LastSong, Title);
        return SongString + "\\Chr=\"Normal\"\\";
    }
}