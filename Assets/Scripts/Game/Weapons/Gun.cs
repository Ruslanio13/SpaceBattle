using UnityEngine;

[RequireComponent (typeof(BulletGenerator))]
public class Gun : MonoBehaviour
{
    private BulletGenerator _generator;
    private void Start()
    {
        _generator = GetComponent<BulletGenerator>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    private void Shoot()
    {
        var bullet = _generator.TryGetObject();
        if (bullet == null)
            return;
        
        bullet.gameObject.transform.rotation = transform.rotation;
        bullet.Move(transform.up);
        bullet.transform.parent = Camera.main.transform;
    }
}
