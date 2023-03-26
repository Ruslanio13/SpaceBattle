using UnityEngine;

public class PlayerMover : MonoBehaviour, IMovable
{
    [SerializeField] private float _moveSpeed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            Move();
    }

    public void Move()
    {
        transform.position += transform.up * (_moveSpeed * Time.deltaTime);
    }
}