using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public abstract class Enemy : Entity, IMovable, IRotatable
{
    [SerializeField] protected float _attackCooldown;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private BonusHandler _bonusHandler;
    
    protected Transform _target;
    protected Rigidbody2D _rigidbody;

    private bool _isRunningAway;
    private BulletGenerator _generator;
        
    protected override void Start()
    {
        base.Start();
        OnDeath.AddListener(_bonusHandler.TryDropBonus);
        OnDeath.AddListener(VictoryChecker.Instance.onEnemyDeath.Invoke);
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

    private void OnEnable()
    {
        _generator = GetComponent<BulletGenerator>();
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        var cooldown = new WaitForSeconds(_attackCooldown);
        while (gameObject.activeSelf)
        {
            var bullet = _generator.TryGetObject();
            if (bullet is null)
            {
                yield return cooldown;
                continue;
            }

            bullet.transform.rotation = transform.rotation;
            bullet.Move(transform.up);
            bullet.transform.parent = Camera.main.transform;
            yield return cooldown;
        }
    }
    
    private Vector3 CalculateMovementVector() => _target.position - transform.position;
    
    public void Move(Vector3 movementVector)
    {
        if(_isRunningAway)
            return;
        _rigidbody.velocity = movementVector.normalized * _moveSpeed;
    }

    public void Rotate(Vector3 rotateToDir)
    {
        if(_isRunningAway)
            return;
        float rotZ = Mathf.Atan2(rotateToDir.y, rotateToDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);
    }


    public void RunAway()
    {
        var newDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        Move(newDir);
        Rotate(newDir);
        StopAllCoroutines();
        _isRunningAway = true;
    }
    
}
