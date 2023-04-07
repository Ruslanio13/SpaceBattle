using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class VictoryChecker : MonoBehaviour
{
    [SerializeField] private TMP_Text _enemiesAmountText;
    public UnityEvent onEnemyDeath;
    public static VictoryChecker Instance;

    private int _enemiesAmount;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _enemiesAmount = 0;
        onEnemyDeath = new UnityEvent();
        onEnemyDeath.AddListener(() => DecreaseEnemiesAmount());
    }

    public void SetGoal(int enemiesAmount)
    {
        Debug.Log(enemiesAmount);
        _enemiesAmount = enemiesAmount;
        SetEnemiesAmountText(_enemiesAmount);
    }
    private void DecreaseEnemiesAmount()
    {
        _enemiesAmount--;
        SetEnemiesAmountText(_enemiesAmount);
        if (_enemiesAmount == 0)
            GameStateMachine.Instance.OnVictory.Invoke();
    }

    private void SetEnemiesAmountText(int amount) => _enemiesAmountText.text = amount.ToString();

}
