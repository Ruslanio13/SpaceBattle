using UnityEngine;

public abstract class Entity : MonoBehaviour, IHitable
{ 
    [SerializeField] protected int healthPoints;
    public Health Health { get; protected set; }
    
    protected virtual void Start()
    {
        Health = new Health(healthPoints);
    }
    
    public virtual void ResetHealth()
    {
        if (Health is null)
            Health = new Health(healthPoints);
        Health.Reset();
    }
    
    public virtual void TakeHit(int damagePoints)
    {
        Health.OnDecreased.Invoke(damagePoints);
        if (Health.CurrentHealthPoints <= 0)
            Die();
    }

    protected void Die()
    {
        gameObject.SetActive(false);
    }
}
