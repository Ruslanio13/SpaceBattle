using UnityEngine.Events;
public class Health : IDecreasable
{
    public int CurrentHealthPoints { get; private set; }
    public int StartHealthPoints { get; private set; }

    public UnityEvent<int> OnDecreased;

    public Health(int startHealthPoints)
    {
        OnDecreased = new UnityEvent<int>();
        StartHealthPoints = startHealthPoints;
        CurrentHealthPoints = startHealthPoints;
        OnDecreased.AddListener(Decrease);
    }

    ~Health()
    {
        OnDecreased.RemoveAllListeners();
    }

    public void Reset()
    {
        CurrentHealthPoints = StartHealthPoints;
    }

    public void Decrease(int points)
    {
        CurrentHealthPoints -= points;
    }
}
