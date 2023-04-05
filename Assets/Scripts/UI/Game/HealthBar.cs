using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Sprite _enadledHearth;
    [SerializeField] private Sprite _disadledHearth;
    [SerializeField] private Image[] _hearths;
    [SerializeField] private Transform _buffer;
    private Health _health;

    public void Initialize(Entity healthOwner)
    {
        _health = healthOwner.Health;
        _hearths = new Image[_health.StartHealthPoints];
        AddHearts(_hearths.Length);
        _health.OnDecreased.AddListener(DecreaseHearts);
    }

    private void AddHearts(int amount)
    {
        Transform heartFromBuffer;
        for (int i = 0; i < amount; i++)
        {
            heartFromBuffer = _buffer.GetChild(0);
            heartFromBuffer.transform.SetParent(transform);
            heartFromBuffer.gameObject.SetActive(true);
        }
    }
    private void DecreaseHearts(int amount)
    {
        if(transform.childCount == 0)
            return;
        Transform heartFromHealthBar;
        for (int i = 0; i < amount; i++)
        {
            heartFromHealthBar = transform.GetChild(0);
            heartFromHealthBar.transform.SetParent(_buffer);
            heartFromHealthBar.gameObject.SetActive(false);
        }
    }
}
