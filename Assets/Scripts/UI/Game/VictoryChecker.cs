using UnityEngine;
using UnityEngine.Events;

public class VictoryChecker : MonoBehaviour
{
    [SerializeField] private EnemyGenerator[] _enemyGenerators;
    public UnityEvent onEnemyDeath;
    [SerializeField] private int _enemiesAmount;
    public static VictoryChecker Instance;

    private void Awake()
    {
        Instance ??= this;
    }

    private void Start()
    {
        _enemiesAmount = 0;
        onEnemyDeath = new UnityEvent();
        onEnemyDeath.AddListener(() => DecreaseEnemiesAmount());
        foreach (var generator in _enemyGenerators)
            _enemiesAmount += generator.GetEnemiesAmount();
    }

    private void DecreaseEnemiesAmount()
    {
        if (--_enemiesAmount == 0)
            GameStateMachine.Instance.OnVictory.Invoke();
    }
}
