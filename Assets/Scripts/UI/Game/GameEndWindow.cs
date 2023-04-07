using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public abstract class GameEndWindow : MonoBehaviour
{
    [SerializeField] private Button _menuButton;
    [SerializeField] private Button _newLevelButton;
    private Animator _animator;

    private void Start()
    {
        _menuButton.onClick.AddListener(() => SceneManager.LoadScene("Menu"));
        _newLevelButton.onClick.AddListener(LoadLevel);
        _animator = GetComponent<Animator>();
        _animator.Play("Appear");
    }

    protected abstract void LoadLevel();
}
