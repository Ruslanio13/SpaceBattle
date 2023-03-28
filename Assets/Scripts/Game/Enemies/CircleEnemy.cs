
using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BulletGenerator))]
public class CircleEnemy : Enemy
{
    private BulletGenerator _generator;

    private void OnEnable()
    {
        _generator = GetComponent<BulletGenerator>();
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        var cooldown = new WaitForSeconds(_attackCooldown);
        while (gameObject.activeSelf)
        {
            var bullet = _generator.TryGetObject();
            if (bullet is null)
            {
                yield return cooldown;
                continue;
            }

            bullet.transform.rotation = transform.rotation;
            bullet.Move(transform.up);
            bullet.transform.parent = Camera.main.transform;
            yield return cooldown;
        }
    }
}
