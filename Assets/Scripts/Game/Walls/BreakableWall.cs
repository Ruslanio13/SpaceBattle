using UnityEngine;

public class BreakableWall : Entity
{
    private void Start()
    {
        _health = new Health(healthPoints);
    }
}
