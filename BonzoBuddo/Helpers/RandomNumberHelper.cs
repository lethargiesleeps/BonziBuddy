namespace BonzoBuddo.Helpers;

/// <summary>
///     Static helper class that creates a random integer, and records previous values used.
/// </summary>
public static class RandomNumberHelper
{
    public static int CurrentValue { get; private set; }
    public static int PreviousValue { get; private set; }
    public static int UpperBound { get; private set; }

    /// <summary>
    ///     Creates a random integer dependent on size of list provided.
    /// </summary>
    /// <param name="list">List of items to iterate.</param>
    public static void SetIndex(IEnumerable<object>? list)
    {
        var random = new Random();
        UpperBound = list!.Count();
        CurrentValue = random.Next(0, UpperBound);
    }

    /// <summary>
    ///     Set UpperBound manually, use if number of elements or results is known ahead of time.
    /// </summary>
    /// <param name="upperBound">Highest value achievable from RNG</param>
    public static void SetIndex(int upperBound)
    {
        var random = new Random();
        UpperBound = upperBound;
        CurrentValue = random.Next(0, UpperBound);
    }

    /// <summary>
    ///     Records last used index for later use.
    /// </summary>
    public static void SetPreviousIndex()
    {
        PreviousValue = CurrentValue;
    }
}