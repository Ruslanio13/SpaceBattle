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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            return;

        gameObject.SetActive(false);
        if (collision.gameObject.TryGetComponent(out IHitable enemyHealth))
            Hit(enemyHealth);
    }

    protected override void Hit(IHitable obj)
    {
        obj.TakeHit(_damagePoints);
    }
}
