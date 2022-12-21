namespace BonzoBuddo.BonziAI.Interfaces;

public interface IRandomizable
{
    public int GetCurrentValue();
    public int GetPreviousValue();
    public void SetPreviousValue();
    public void SetCurrentValue();
    public void SetUpperBound(int upperBound);
}