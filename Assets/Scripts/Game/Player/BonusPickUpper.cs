using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class BonusPickUpper : MonoBehaviour
{
    [SerializeField] private Gun _playerGun;
    [SerializeField] private Player _player; 

    private PlayerMover _playerMover;
    private Health _playerHealth;
    
    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Bonus bonus))
            if (bonus is SpeedUp)
                bonus.GiveBonus(_playerMover);
            else if (bonus is AttackSpeedUp)
                bonus.GiveBonus(_playerGun);
            else if (bonus is HealthUp)
            {
                _playerHealth ??= _player.Health;
                bonus.GiveBonus(_playerHealth);
            }
    }
}
