using UnityEngine;
[RequireComponent(typeof(PlayerMover))]
public class Player : Entity
{
    [SerializeField] private PlayerHealthBar healthBar;
    protected override void Start()
    {
        base.Start();
        healthBar.Initialize(this);
        OnDeath.AddListener(() => GameStateMachine.Instance.OnGameOver.Invoke());
        GameStateMachine.Instance.OnGameOver.AddListener(() => gameObject.SetActive(false));
        GameStateMachine.Instance.OnVictory.AddListener(() => gameObject.SetActive(false));
    }
}