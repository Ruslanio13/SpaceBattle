using UnityEngine;

public class BreakableWall : MonoBehaviour, IHitable
{
    [SerializeField] private int _healthPoints;
    private Health _health;

    private void Start()
    {
        _health = new Health(_healthPoints);
    }

    public void TakeHit(int damagePoints)
    {
        _health.Decrease(damagePoints);
        if (_health.CurrentHealthPoints <= 0)
            Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
