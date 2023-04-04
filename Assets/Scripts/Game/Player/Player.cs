using System;
using UnityEngine;
[RequireComponent(typeof(PlayerMover))]
public class Player : Entity
{
    [SerializeField] private HealthBar healthBar;
    private PlayerMover _playerMover;
    
    protected override void Start()
    {
        base.Start();
        _playerMover = GetComponent<PlayerMover>();
        healthBar.Initialize(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out Bonus bonus))
            bonus.GiveBonus(_playerMover);
    }
}
