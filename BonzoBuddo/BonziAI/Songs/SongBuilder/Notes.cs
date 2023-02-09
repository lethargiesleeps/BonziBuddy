namespace BonzoBuddo.BonziAI.Songs.SongBuilder;

/// <summary>
///     This class contains static Note objects with their pitch set to their corresponding letter note values.
/// </summary>
public static class Notes
{
    public static Note GSharp = new(NoteType.GSharp);
    public static Note G = new(NoteType.G);
    public static Note F = new(NoteType.F);
    public static Note FSharp = new(NoteType.FSharp);
    public static Note E = new(NoteType.E);
    public static Note D = new(NoteType.D);
    public static Note DSharp = new(NoteType.DSharp);
    public static Note C = new(NoteType.C);
    public static Note CSharp = new(NoteType.CSharp);
    public static Note B = new(NoteType.B);
    public static Note A = new(NoteType.A);
    public static Note ASharp = new(NoteType.ASharp);
    public static List<Note> CustomNotes = new();


    /// <summary>
    ///     Resets all the Notes in this class to their initial value. Should be used if pitch is ever adjusted during song
    ///     building.
    /// </summary>
    public static void ResetNotes()
    {
        GSharp = new Note(NoteType.GSharp);
        G = new Note(NoteType.G);
        F = new Note(NoteType.F);
        FSharp = new Note(NoteType.FSharp);
        E = new Note(NoteType.E);
        D = new Note(NoteType.D);
        DSharp = new Note(NoteType.DSharp);
        C = new Note(NoteType.C);
        CSharp = new Note(NoteType.CSharp);
        B = new Note(NoteType.B);
        A = new Note(NoteType.A);
        ASharp = new Note(NoteType.ASharp);
    }
}