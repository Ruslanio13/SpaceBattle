using UnityEngine.Events;
public class Health : IDecreasable, IUpgradeable
{
    public int CurrentHealthPoints { get; private set; }
    public int StartHealthPoints { get; private set; }

    public UnityEvent OnDecreased;
    public UnityEvent OnIncreased;

    public Health(int startHealthPoints)
    {
        OnDecreased = new UnityEvent();
        OnIncreased = new UnityEvent();
        StartHealthPoints = startHealthPoints;
        CurrentHealthPoints = startHealthPoints;
        OnDecreased.AddListener(Decrease);
        OnIncreased.AddListener(Increase);
    }

    ~Health()
    {
        OnDecreased.RemoveAllListeners();
        OnIncreased.RemoveAllListeners();
    }

    public void GetUpgrade(int amount)
    {
        OnIncreased.Invoke();
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
        if (CurrentHealthPoints < StartHealthPoints)
            CurrentHealthPoints++;
    }
}
