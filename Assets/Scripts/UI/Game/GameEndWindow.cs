using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public abstract class GameEndWindow : MonoBehaviour
{
    [SerializeField] private Button _menuButton;
    [SerializeField] private Button _newLevelButton;

    private void Start()
    {
        _menuButton.onClick.AddListener(() => SceneManager.LoadScene("Menu"));
        _newLevelButton.onClick.AddListener(() => LoadLevel());
    }

    protected abstract void LoadLevel();
}
