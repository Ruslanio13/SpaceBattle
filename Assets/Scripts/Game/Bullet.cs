using UnityEngine;

public class Bullet : Projectile, IMovable
{
    private void Update()
    {
        Move(transform.up);
    }

    public void Move(Vector3 dir)
    {
        transform.position += dir * (_speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
        if (collision.gameObject.TryGetComponent(out IHitable enemyHealth))
            Hit(enemyHealth);
    }

    protected override void Hit(IHitable obj)
    {
        obj.TakeHit(_damagePoints);
    }
}
