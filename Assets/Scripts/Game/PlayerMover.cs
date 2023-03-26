using UnityEngine;

public class PlayerMover : MonoBehaviour, IMovable
{
    [SerializeField] private float _moveSpeed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
            Move(Mathf.Sin(transform.eulerAngles.z - 90) * -transform.up);
        if (Input.GetKey(KeyCode.D))
            Move(Mathf.Cos(transform.eulerAngles.z - 90) * -transform.right);
        if (Input.GetKey(KeyCode.S))
            Move(Mathf.Sin(transform.eulerAngles.z - 90) * transform.up);
        if (Input.GetKey(KeyCode.A))
            Move(Mathf.Cos(transform.eulerAngles.z - 90) * transform.right);

    }

    public void Move(Vector3 dir)
    {
        transform.position += dir.normalized * (_moveSpeed * Time.deltaTime);
    }
}