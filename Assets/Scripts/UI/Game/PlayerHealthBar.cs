using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : HealthBar
{
    [SerializeField] private Sprite _enadledHearth;
    [SerializeField] private Image[] _hearths;
    [SerializeField] private Transform _buffer;
    [SerializeField] private Transform _healthBarTransform;

    protected override void UpdateHealthBar()
    {
        var diff = _healthBarTransform.childCount - _health.CurrentHealthPoints;
        if (diff > 0)
            for (int i = 0; i < diff; i++)
            {
                Transform heartFromHealthBar = _healthBarTransform.GetChild(0);
                heartFromHealthBar.transform.SetParent(_buffer);
                heartFromHealthBar.gameObject.SetActive(false);
            }
        else if (diff < 0)
            for (int i = 0; i < -diff; i++)
            {
                Transform heartFromBuffer = _buffer.GetChild(0);
                heartFromBuffer.transform.SetParent(_healthBarTransform);
                heartFromBuffer.gameObject.SetActive(true);
            }
    }
}
