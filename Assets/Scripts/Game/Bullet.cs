using UnityEngine;

public class Bullet : MonoBehaviour, IMovable
{
    [SerializeField] private float _speed;

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.position += transform.up * (_speed * Time.deltaTime);
    }
}
