using UnityEngine;

public class PlayerLooker : MonoBehaviour
{
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }
    private void Update()
    {
        Vector2 posDiff = _mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        posDiff.Normalize();
        float rotZ = Mathf.Atan2(posDiff.y, posDiff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);
    }
}
