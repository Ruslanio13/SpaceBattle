using System.Collections.Generic;
using UnityEngine;

public class BonusHandler : MonoBehaviour
{
    [SerializeField] private List<Bonus> _bonusTemplates;
    [SerializeField] private float _probability;

    public void TryDropBonus()
    {
        int generatedIndex = GenerateRandomIndex();
        if (generatedIndex == -1)
            return;
        var bonus = Instantiate(_bonusTemplates[generatedIndex], Camera.main.transform);
        bonus.transform.position = transform.position;
    }

    private int GenerateRandomIndex()
    {
        var result = Random.Range(0, 100);
        return result < _probability ? Random.Range(0, _bonusTemplates.Count) : -1;
    }
}
