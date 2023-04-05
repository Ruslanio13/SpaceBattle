using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : Bonus
{
    public override void GiveBonus(IUpgradeable target)
    {
        base.GiveBonus(target);
        target.GetUpgrade(_percentage);
    }
}
