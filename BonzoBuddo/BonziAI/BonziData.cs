namespace BonzoBuddo.BonziAI;

[Serializable]
public class BonziData
{
    public string Name { get; set; }
    public float BonziScore { get; set; }
    public DateTime LastAccessed { get; set; }
    public string City { get; set; }
}