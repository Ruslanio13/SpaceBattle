using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class Entity : MonoBehaviour, IHitable
{ 
    [SerializeField] protected int healthPoints;
    public Health Health { get; protected set; }
    protected UnityEvent OnDeath; 

    protected virtual void Start()
    {
        OnDeath = new UnityEvent();
        Health = new Health(healthPoints);
    }
    
    public virtual void ResetHealth()
    {
        if (Health is null)
            Health = new Health(healthPoints);
        Health.Reset();
    }
    
    public virtual void TakeHit()
    {
        Health.OnDecreased.Invoke();
        if (Health.CurrentHealthPoints <= 0)
            Die();
    }

    protected virtual void Die()
    {
        gameObject.SetActive(false);
        OnDeath?.Invoke();
    }
    
    private void OnApplicationQuit()
    {
        OnDeath.RemoveAllListeners();
    }
}
