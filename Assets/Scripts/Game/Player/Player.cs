using System;
using UnityEngine;
[RequireComponent(typeof(PlayerMover))]
public class Player : Entity
{
    [SerializeField] private HealthBar healthBar;
    protected override void Start()
    {
        base.Start();
        healthBar.Initialize(this);
    }
}
