using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : AbstractGenerator<Bullet>
{
    [SerializeField] private int _capacity;

    private void Start()
    {
        Generate(_capacity);
    }
}
