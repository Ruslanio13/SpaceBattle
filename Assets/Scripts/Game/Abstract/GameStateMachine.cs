using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameStateMachine : MonoBehaviour
{
    [SerializeField] private GameObject[] _levels;
    public static GameStateMachine Instance;
    private int _currentLevelNumber;

    public UnityEvent OnGameOver;
    public UnityEvent OnVictory;
    private void Awake()
    {
        Instance ??= this;
        OnGameOver = new UnityEvent();
        OnVictory = new UnityEvent();
        DontDestroyOnLoad(this);
    }

    public void LoadLevel(int levelNumber)
    {
        _currentLevelNumber = levelNumber <= _levels.Length ? levelNumber : 1;
        LoadLevel();
    }

    public void LoadLevel() => SceneManager.LoadScene("Game");

    public void GoNextLevel() => LoadLevel(_currentLevelNumber + 1);

    public void GenerateLevel() => Instantiate(_levels[_currentLevelNumber - 1]);
}
