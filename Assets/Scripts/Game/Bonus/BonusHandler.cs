using System.Collections.Generic;
using UnityEngine;

public class BonusHandler : MonoBehaviour
{
    [SerializeField] private List<Bonus> _bonusTemplates;

    public void TryDropBonus()
    {
        var bonus = Instantiate(_bonusTemplates[0], Camera.main.transform);
        bonus.transform.position = transform.position;
    }
}
