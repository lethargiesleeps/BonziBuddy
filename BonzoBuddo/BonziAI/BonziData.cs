namespace BonzoBuddo.BonziAI;

/// <summary>
///     Model for Bonzi Buddy user. This data is serialized to a file and used for user interaction.
/// </summary>
public class BonziData
{
    public string? Name { get; set; }
    public string? City { get; set; }
    public DateTime LastAccessed { get; set; }
    public DateTime DateCreated { get; set; }
}