using System.Text;

namespace BonzoBuddo.BonziAI.Songs.SongBuilder;

public class Song
{
    //TODO: Document
    public List<Note> Notes { get; private set; }
    public string Title { get; private set; }
    public StringBuilder SongString { get; private set; }
    public int InitialSpeed { get; private set; }
    

    public Song(string title)
    {
        Notes = new List<Note>();
        Title = title;
        SongString.Append("\\Chr=\"Monotone\"\\");
        if (InitialSpeed > 0)
        {
            SongString.Append($"\\Spd={InitialSpeed}\\");
        }
    }

    public Song AddNote(Note note)
    {
        //TODO: If speed is different than initial speed
        Notes.Add(note);
        SongString.AppendLine(note.ToString());
        return this;
    }
    public Song SetInitialSpeed(int speed)
    {
        InitialSpeed = speed;
        return this;
    }
    public override string ToString()
    {
        return SongString.ToString();
    }
}