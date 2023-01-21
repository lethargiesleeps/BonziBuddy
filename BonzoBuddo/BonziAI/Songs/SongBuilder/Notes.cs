using System.Net.NetworkInformation;

namespace BonzoBuddo.BonziAI.Songs.SongBuilder;

/// <summary>
/// This class contains static Note objects with their pitch set to their corresponding letter note values.
/// </summary>
public static class Notes
{
    public static Note GSharp = new (NoteType.GSharp);
    public static Note G = new (NoteType.G);
    public static Note F = new (NoteType.F);
    public static Note FSharp = new (NoteType.FSharp);
    public static Note E = new (NoteType.E);
    public static Note D = new (NoteType.D);
    public static Note DSharp = new (NoteType.DSharp);
    public static Note C = new (NoteType.C);
    public static Note CSharp = new(NoteType.CSharp);
    public static Note B = new (NoteType.B);
    public static Note A = new(NoteType.A);
    public static Note ASharp = new(NoteType.ASharp);
    public static List<Note> CustomNotes = new();

    /// <summary>
    /// Resets all the Notes in this class to their initial value. Should be used if pitch is ever adjusted during song building.
    /// </summary>
    public static void ResetNotes()
    {
        GSharp = new(NoteType.GSharp);
        G = new(NoteType.G);
        F = new(NoteType.F);
        FSharp = new(NoteType.FSharp);
        E = new(NoteType.E);
        D = new(NoteType.D);
        DSharp = new(NoteType.DSharp);
        C = new(NoteType.C);
        CSharp = new(NoteType.CSharp);
        B = new(NoteType.B);
        A = new(NoteType.A);
        ASharp = new(NoteType.ASharp);
    }
}