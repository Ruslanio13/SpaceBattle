using UnityEngine;

public abstract class Projectile : MonoBehaviour, IHit
{
    [SerializeField] protected float _speed;
    [SerializeField] protected int _damagePoints;
    protected string _allianceTag; 
    public void Attack(IHitable obj)
    {
        obj.TakeHit();
    }

    public void SetAlliance(string tag)
    {
        _allianceTag = tag;
    }
}
