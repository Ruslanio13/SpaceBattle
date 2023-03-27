using UnityEngine;

public class Health : IDecreasable
{
    public int CurrentHealthPoints { get; private set; }

    public Health(int _startHealthPoints)
    {
        CurrentHealthPoints = _startHealthPoints;
    }

    public virtual void Decrease(int points)
    {
        CurrentHealthPoints -= points;
    }
}
