using UnityEngine;
using UnityEngine.UI;

public class MothershipHealthBar : HealthBar
{
    [SerializeField] private Image _healthBarBackground;
    [SerializeField] private Image _healthBarFilled;

    protected override void UpdateHealthBar()
    {
        _healthBarFilled.fillAmount = (float)_health.CurrentHealthPoints / (float)_health.StartHealthPoints;
    }
}
