using UnityEngine;

public class Mothership : Entity
{
    [SerializeField] private MothershipHealthBar healthBar;

    protected override void Start()
    {
        base.Start();
        healthBar.Initialize(this);
        OnDeath.AddListener(() => GameStateMachine.Instance.OnGameOver.Invoke());
    }
}
