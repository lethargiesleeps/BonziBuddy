using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BonzoBuddo.BonziAI.Songs.SongBuilder;

public class Note
{
    //TODO: Document
    public int Pitch { get; private set; }
    public int Speed { get; private set; }

    public string Syllable { get; private set; } = string.Empty;

    public Note(NoteType note)
    {
        SetPitch(note);
    }



    public Note SetSyllable(string syllable)
    {
        Syllable = syllable;
        return this;
    }
    public Note AddSpeed(int value)
    {
        Speed += value;
        return this;
    }

    public Note SubtractSpeed(int value)
    {
        Speed -= value;
        return this;
    }

    public Note ResetSpeed()
    {
        Speed = 0;
        return this;
    }

    public Note ResetPitch(NoteType note)
    {
        SetPitch(note); 
        return this;
    }

    public Note AdjustPitch(int value)
    {
        if(value >= 12)
            value = 12;
        if(value <= -12)
            value = -12;
        Pitch += value;
        return this;
    }
    
    public Note ChangeSpeed(int value)
    {
        Speed = value;
        return this;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        return "";
    }
    private void SetPitch(NoteType note)
    {
        switch (note)
        {
            case NoteType.GSharp:
                Pitch = 208;
                break;
            case NoteType.A:
                Pitch = 220;
                break;
            case NoteType.ASharp:
                Pitch = 233;
                break;
            case NoteType.B:
                Pitch = 247;
                break;
            case NoteType.C:
                Pitch = 262;
                break;
            case NoteType.CSharp:
                Pitch = 277;
                break;
            case NoteType.D:
                Pitch = 294;
                break;
            case NoteType.DSharp:
                Pitch = 311;
                break;
            case NoteType.E:
                Pitch = 330;
                break;
            case NoteType.F:
                Pitch = 349;
                break;
            case NoteType.FSharp:
                Pitch = 370;
                break;
            case NoteType.G:
                Pitch = 392;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(note), note, null);
        }

    }
}