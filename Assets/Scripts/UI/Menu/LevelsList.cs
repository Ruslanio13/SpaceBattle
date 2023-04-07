using UnityEngine;

public class LevelsList : MonoBehaviour
{
    [SerializeField] private LevelButton[] _levelButtons;

    private void Start()
    {
        int maxLvl = SaveManager.Instance.loadedSave.MaxReachedLevel;
        for (int i = 0; i < _levelButtons.Length; i++)
        {
            _levelButtons[i].SetLevelButtonActive(maxLvl > i);
        }
    }
}
