public class AttackSpeedUp : Bonus
{
    public override void GiveBonus(IUpgradeable target)
    {
        base.GiveBonus(target);
        target.GetUpgrade(_percentage);
    }
}
