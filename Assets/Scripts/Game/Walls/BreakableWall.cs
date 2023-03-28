using UnityEngine;

public class BreakableWall : Entity
{
    protected override void Start()
    {
        base.Start();
        _health = new Health(healthPoints);
    }
}
