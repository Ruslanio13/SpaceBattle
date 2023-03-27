using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected int _damagePoints;

    protected abstract void Hit(IHitable hitable);
}
