using UnityEngine;

public class PlayerMover : MonoBehaviour, IMovable
{
    [SerializeField] private float _moveSpeed;
    private Vector3 _direction;

    private void Start()
    {
        _direction = Vector3.zero;
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
        _direction.x = dx;
        _direction.y = dy;
    }

    public void Move(Vector3 dir)
    {
        transform.position += dir.normalized * (_moveSpeed * Time.deltaTime);
    }
}