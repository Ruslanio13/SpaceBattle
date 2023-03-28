using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Bullet : Projectile, IMovable
{
    private Rigidbody2D _rigidbody2D;

    private void OnEnable()
    {
        if (_rigidbody2D == null)
            _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void Move(Vector3 dir)
    {
        _rigidbody2D.velocity = dir * _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(_allianceTag))
            return;
        gameObject.SetActive(false);
        if (collision.gameObject.TryGetComponent(out IHitable target))
            Attack(target);
    }
    

}
