using UnityEngine;

public class BodyRotator : MonoBehaviour
{
    private void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        var direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg);
    }
}