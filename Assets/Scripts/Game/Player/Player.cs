using System.Collections;
using UnityEngine;
[RequireComponent(typeof(PlayerMover))]
public class Player : Entity
{
    [SerializeField] private PlayerHealthBar _healthBar;
    [SerializeField] private float _invincibleTime;
    [SerializeField] private Animator _animator;
    protected override void Start()
    {
        base.Start();
        _healthBar.Initialize(this);
        OnDeath.AddListener(() => GameStateMachine.Instance.OnGameOver.Invoke());
        GameStateMachine.Instance.OnGameOver.AddListener(() => gameObject.SetActive(false));
        GameStateMachine.Instance.OnVictory.AddListener(() => gameObject.SetActive(false));
    }

    public override void TakeHit()
    {
        base.TakeHit();
        if (Health.CurrentHealthPoints > 0)
            StartCoroutine(InvincibleTime());
    }

    private IEnumerator InvincibleTime()
    {
        gameObject.layer = 12;
        _animator.Play("Invincible");
        yield return new WaitForSeconds(_invincibleTime);
        _animator.Play("PlayerIdle");
        gameObject.layer = 3;
    }
}