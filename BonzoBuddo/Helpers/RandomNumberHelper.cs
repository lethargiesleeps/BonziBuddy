namespace BonzoBuddo.Helpers;

public static class RandomNumberHelper
{
    public static int CurrentValue { get; private set; }
    public static int PreviousValue { get; private set; }
    public static int  UpperBound { get; private set; }

    public static void SetIndex(IEnumerable<object> list)
    {
        Random random = new Random();
        UpperBound = list.Count();
        CurrentValue = random.Next(0, UpperBound);
        
    }

    public static void SetPreviousIndex()
    {
        PreviousValue = CurrentValue;
    }
}