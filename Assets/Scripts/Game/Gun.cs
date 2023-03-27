using UnityEngine;

[RequireComponent (typeof(BulletGenerator))]
public class Gun : MonoBehaviour
{
    private BulletGenerator _generator;
    [SerializeField] private Transform _generatePoint;
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
        var bullet = _generator.GetObject();
        if (bullet == null)
            return;
        bullet.gameObject.transform.position = _generatePoint.position;
        bullet.gameObject.transform.rotation = transform.rotation;
        bullet.transform.parent = Camera.main.transform;
    }
}
