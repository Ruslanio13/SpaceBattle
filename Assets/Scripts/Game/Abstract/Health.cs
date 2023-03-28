using UnityEngine;

public class Health : IDecreasable
{
    public int CurrentHealthPoints { get; private set; }
    private int _startHealthPoints;
    public Health(int startHealthPoints)
    {
        _startHealthPoints = startHealthPoints;
        CurrentHealthPoints = startHealthPoints;
    }

    public void Reset()
    {
        CurrentHealthPoints = _startHealthPoints;
    }
    public virtual void Decrease(int points)
    {
        CurrentHealthPoints -= points;
    }
}
