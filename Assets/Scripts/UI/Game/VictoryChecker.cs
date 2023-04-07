using UnityEngine;
using UnityEngine.Events;

public class VictoryChecker : MonoBehaviour
{
    public UnityEvent onEnemyDeath;
    public static VictoryChecker Instance;

    private int _enemiesAmount;
    
    private void Awake()
    {
        Instance ??= this;
    }

    private void Start()
    {
        _enemiesAmount = 0;
        onEnemyDeath = new UnityEvent();
        onEnemyDeath.AddListener(() => DecreaseEnemiesAmount());
    }

    public void SetGoal(int enemiesAmount)
    {
        _enemiesAmount = enemiesAmount;
    }
    private void DecreaseEnemiesAmount()
    {
        _enemiesAmount--;
        if (_enemiesAmount == 0)
            GameStateMachine.Instance.OnVictory.Invoke();
    }
}
