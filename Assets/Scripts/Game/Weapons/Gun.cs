using UnityEngine;

[RequireComponent (typeof(BulletGenerator))]


public class Gun : MonoBehaviour, IUpgradeable
{
    [SerializeField] private float _initialCooldown;
    private float _cooldown;
    private float _lastShotTime;
    private BulletGenerator _generator;
    private void Start()
    {
        _cooldown = _initialCooldown;
        _generator = GetComponent<BulletGenerator>();
        _lastShotTime = Time.time;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && !OnCooldown())
            Shoot();
    }

    private bool OnCooldown() => (Time.time - _lastShotTime)  <= _cooldown;
    private void Shoot()
    {
        var bullet = _generator.TryGetObject();
        if (bullet == null)
            return;
        
        bullet.gameObject.transform.rotation = transform.rotation;
        bullet.Move(transform.up);
        bullet.transform.parent = Camera.main.transform;
        _lastShotTime = Time.time;
    }

    public void GetUpgrade(int percentage)
    {
        _cooldown -= _initialCooldown * percentage;
    }
}
