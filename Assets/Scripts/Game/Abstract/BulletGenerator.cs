
using UnityEngine;

public class BulletGenerator : AbstractGenerator<Bullet>
{
    private string _allianceTag;
    private void Start()
    {
        Generate();
    }

    protected override void Generate()
    {
        for (int i = 0; i < _capacity; i++)
        {
            var temp = Instantiate(_template, transform);
            temp.gameObject.SetActive(false);
            temp.SetAlliance(gameObject.tag);
            _generatedObjects.Add(temp.gameObject);
        }
    }
}
