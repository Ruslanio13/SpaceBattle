using UnityEngine;

public class Bullet : MonoBehaviour, IMovable
{
    [SerializeField] private float _speed;

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
        Debug.Log("Aww");
    }
}
