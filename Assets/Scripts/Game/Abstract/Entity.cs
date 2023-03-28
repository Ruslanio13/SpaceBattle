using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Entity : MonoBehaviour, IHitable
{ 
    [SerializeField] protected int healthPoints;
    protected Health _health;
    
    
    public virtual void ResetHealth()
    {
        if (_health is null)
            _health = new Health(healthPoints);
        _health.Reset();
    }
    
    public virtual void TakeHit(int damagePoints)
    {
        _health.Decrease(damagePoints);
        if (_health.CurrentHealthPoints <= 0)
            Die();
    }

    protected void Die()
    {
        gameObject.SetActive(false);
    }
}
