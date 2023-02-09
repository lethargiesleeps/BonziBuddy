namespace BonzoBuddo.BonziAI.Songs.SongBuilder;

/// <summary>
///     A note to be played when creating a song.
/// </summary>
/// <see cref="Song" />
public class Note
{
    /// <summary>
    ///     Constructor used when creating predetermined notes.
    /// </summary>
    /// <param name="note">The note type.</param>
    /// <see cref="Notes" />
    /// <seealso cref="NoteType" />
    public Note(NoteType note)
    {
        SetPitch(note);
    }

    /// <summary>
    ///     Constructor when adding a new note to a song with a syllable.
    /// </summary>
    /// <param name="note">The note type.</param>
    /// <param name="syllable">What displays in Bonzi's speech bubble</param>
    /// <see cref="Notes" />
    /// <seealso cref="NoteType" />
    public Note(NoteType note, string syllable)
    {
        SetPitch(note);
        Syllable = syllable;
    }

    public int Pitch { get; private set; }
    public string Syllable { get; private set; } = string.Empty;

    /// <summary>
    ///     Manually sets the syllable if its needs to change.
    /// </summary>
    /// <param name="syllable">What displays in Bonzi's speech bubble.</param>
    /// <returns>The current note object.</returns>
    public Note SetSyllable(string syllable)
    {
        Syllable = syllable;
        return this;
    }

    /// <summary>
    ///     Resets the note to it's original value.
    /// </summary>
    /// <param name="note">The type of note to reset.</param>
    /// <returns>The current note object.</returns>
    public Note ResetPitch(NoteType note)
    {
        SetPitch(note);
        return this;
    }

    /// <summary>
    ///     Adjusts the note's pitch.
    ///     WARNING: This might affect predetermined notes permanently.
    ///     Use ResetPitch(NoteType note) after using this method.
    /// </summary>
    /// <param name="value">Value to increment or decrement.</param>
    /// <returns>The current note object.</returns>
    public Note AdjustPitch(int value)
    {
        Pitch += value;
        return this;
    }

    /// <summary>
    /// Increases octave of a note.
    /// </summary>
    /// <returns>Returns note at increased octave.</returns>
    public Note IncreaseOctave()
    {
        Pitch *= 2;
        return this;
    }

    /// <summary>
    /// Decreases octave of a note.
    /// </summary>
    /// <returns>Returns note at decreased octave.</returns>
    public Note DecreaseOctave()
    {
        Pitch /= 2;
        return this;
    }

    /// <summary>
    ///     Sets the Note's pitch the numerical value of pitch representing the actual letter notes.
    ///     These are the values for highest octave available from TTS engine.
    /// </summary>
    /// <param name="note">The note to adjust.</param>
    /// <exception cref="ArgumentOutOfRangeException">Throws if invalid argument is used.</exception>
    /// <see cref="Notes" />
    private void SetPitch(NoteType note)
    {
        Pitch = note switch
        {
            NoteType.GSharp => 208,
            NoteType.A => 220,
            NoteType.ASharp => 233,
            NoteType.B => 247,
            NoteType.C => 262,
            NoteType.CSharp => 277,
            NoteType.D => 294,
            NoteType.DSharp => 311,
            NoteType.E => 330,
            NoteType.F => 349,
            NoteType.FSharp => 370,
            NoteType.G => 392,
            _ => throw new ArgumentOutOfRangeException(nameof(note), note, null)
        };
    }

    /// <summary>
    ///     Returns the note data to be added to the Song's TTS string.
    /// </summary>
    /// <returns>A string containing TTS note data.</returns>
    public override string ToString()
    {
        return $"\\Pit={Pitch}\\{Syllable}";
    }
}