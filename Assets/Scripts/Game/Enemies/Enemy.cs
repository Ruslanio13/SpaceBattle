using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Enemy : Entity, IMovable, IRotatable
{
    [SerializeField] protected float _attackCooldown;
    [SerializeField] private float _moveSpeed;

    protected Transform _target;
    protected Rigidbody2D _rigidbody;
    
    protected override void Start()
    {
        base.Start();
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

}
