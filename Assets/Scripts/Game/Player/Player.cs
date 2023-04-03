using UnityEngine;
public class Player : Entity
{
    [SerializeField] private HealthBar healthBar;

    protected override void Start()
    {
        base.Start();
        healthBar.Initialize(this);
    }
}
