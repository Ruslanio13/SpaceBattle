using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(LevelGenerator))]
public class GameStateMachine : MonoBehaviour
{
    [SerializeField] private List<LevelPreset> _levels;

    private LevelGenerator _levelGenerator;
    
    public static GameStateMachine Instance;
    
    public UnityEvent OnGameOver;
    public UnityEvent OnVictory;
    private void Awake()
    {
        Instance ??= this;
        OnGameOver = new UnityEvent();
        OnVictory = new UnityEvent();
        DontDestroyOnLoad(this);
        _levelGenerator = GetComponent<LevelGenerator>();
    }

    public void LoadLevel(int levelNumber)
    {
        _currentLevelNumber = levelNumber <= _levels.Length ? levelNumber : 1;
        LoadLevel();
        _levelGenerator.Generate(_levels[levelNumber]);
    }

    public void LoadLevel() => SceneManager.LoadScene("Game");

    public void GoNextLevel() => LoadLevel(_currentLevelNumber + 1);

    public void GenerateLevel() => Instantiate(_levels[_currentLevelNumber - 1]);
}
