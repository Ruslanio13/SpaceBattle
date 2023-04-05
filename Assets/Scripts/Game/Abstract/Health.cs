using UnityEngine.Events;
public class Health : IDecreasable, IUpgradeable
{
    public int CurrentHealthPoints { get; private set; }
    public int StartHealthPoints { get; private set; }

    public UnityEvent OnDecreased;

    public Health(int startHealthPoints)
    {
        OnDecreased = new UnityEvent();
        StartHealthPoints = startHealthPoints;
        CurrentHealthPoints = startHealthPoints;
        OnDecreased.AddListener(Decrease);
    }

    ~Health()
    {
        OnDecreased.RemoveAllListeners();
    }

    public void GetUpgrade(int amount)
    {
        Increase();
    }

    public void Reset()
    {
        CurrentHealthPoints = StartHealthPoints;
    }

    public void Decrease()
    {
        CurrentHealthPoints--;
    }
    
    public void Increase()
    {
        CurrentHealthPoints++;
    }
}
