using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    [SerializeField] protected int _percentage;
    public virtual void GiveBonus(IUpgradeable target)
    {
        gameObject.SetActive(false);
    }
}
