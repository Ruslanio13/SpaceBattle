using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private BulletGenerator _generator;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    private void Shoot()
    {
        var bullet = _generator.GetObject();
        if (bullet == null)
            return;
        bullet.gameObject.transform.position = transform.position;
        bullet.gameObject.transform.rotation = transform.rotation;
    }
}
