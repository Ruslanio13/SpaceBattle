using UnityEngine;

public abstract class HealthBar : MonoBehaviour
{
    protected Health _health;

    public void Initialize(Entity healthOwner)
    {
        _health = healthOwner.Health;
        _health.OnDecreased.AddListener(UpdateHealthBar);
        UpdateHealthBar();
    }

    protected abstract void UpdateHealthBar();
}
