using UnityEngine;

public class PlayerLooker : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    
    private void Update()
    {
        Vector2 posDiff = mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        posDiff.Normalize();
        float rotZ = Mathf.Atan2(posDiff.y, posDiff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);
    }
}
