using BonzoBuddo.BonziAI.Interfaces;

namespace BonzoBuddo.BonziAI.Tools;

public class RandomListIterator : IRandomizable
{
    private int _currentIndex;
    private int _previousIndex;
    private Random _random;
    private int _lowerBound;
    private int _upperBound;

    public RandomListIterator()
    {
        _random = new Random();
        _lowerBound = 0;
    }
    public int GetCurrentValue()
    {
        return _currentIndex;
    }

    public int GetPreviousValue()
    {
        return _previousIndex;
    }

    public void SetPreviousValue()
    {
        _previousIndex = _currentIndex;
    }

    public void SetCurrentValue()
    {
        _currentIndex = _random.Next(_lowerBound, _upperBound);
    }

    public void SetUpperBound(int upperBound)
    {
        _upperBound = upperBound;
    }
}