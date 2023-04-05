using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Mothership : Entity
{
    protected override void Start()
    {
        base.Start();
        OnDeath.AddListener(() => GameStateMachine.Instance.OnGameOver.Invoke());
    }
}
