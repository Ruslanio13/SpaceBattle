using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour, IMovable, IUpgradeable
{
    [SerializeField] private float _startSpeed;
    private float _moveSpeed;
    private Vector3 _direction;
    private bool[] _collisionDetected;
    private Rigidbody2D _rigidbody;
    
    private void Start()
    {
        _moveSpeed = _startSpeed;
        _collisionDetected = new bool[4];
        _direction = Vector3.zero;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        SetDirection();
        Move(_direction);
    }

    private void SetDirection()
    {
        var dx = Input.GetAxisRaw("Horizontal");
        var dy = Input.GetAxisRaw("Vertical");
        dx = dx > 0 && _collisionDetected[1] ? 0 : dx;
        dx = dx < 0 && _collisionDetected[3] ? 0 : dx;

        dy = dy > 0 && _collisionDetected[0] ? 0 : dy;
        dy = dy < 0 && _collisionDetected[2] ? 0 : dy;
        
        _direction.x = dx;
        _direction.y = dy;
    }

    public void Move(Vector3 dir)
    {
        _rigidbody.velocity = dir.normalized * (_moveSpeed );
    }

    public void GetUpgrade(int upgradePercent)
    {
        _moveSpeed += _moveSpeed * upgradePercent / 100f;
    }
}