using UnityEngine;

public class BreakableWall : Entity
{
    protected override void Start()
    {
        base.Start();
        Health = new Health(healthPoints);
    }
}
