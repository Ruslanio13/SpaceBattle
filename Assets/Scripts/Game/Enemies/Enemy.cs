using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BonusHandler))]

public abstract class Enemy : Entity, IMovable, IRotatable
{
    [SerializeField] protected float _attackCooldown;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private BonusHandler _bonusHandler;
    
    protected Transform _target;
    protected Rigidbody2D _rigidbody;

    private UnityEvent OnDeath; 
        
    protected override void Start()
    {
        base.Start();
        OnDeath = new UnityEvent();
        OnDeath.AddListener(_bonusHandler.TryDropBonus);
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move(CalculateMovementVector());
        Rotate(CalculateMovementVector());
    }
    
    public void SetTarget(Transform target)
    {
        if (target != null)
            _target = target;
    }
    
    private Vector3 CalculateMovementVector() => _target.position - transform.position;
    
    public void Move(Vector3 movementVector)
    {
        _rigidbody.velocity = movementVector.normalized * _moveSpeed;
    }

    public void Rotate(Vector3 rotateToDir)
    {
        float rotZ = Mathf.Atan2(rotateToDir.y, rotateToDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);
    }

    public override void TakeHit(int damagePoints)
    {
        Health.OnDecreased.Invoke(damagePoints);
        if (Health.CurrentHealthPoints <= 0)
            Die();
    }

    protected override void Die()
    {
        base.Die();
        OnDeath?.Invoke();
    }
    
}
