using System.Collections.Generic;
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

    private void Awake()
    {
        Instance ??= this;
        OnGameOver = new UnityEvent();
        DontDestroyOnLoad(this);
        _levelGenerator = GetComponent<LevelGenerator>();
    }

    public void LoadLevel(int levelNumber)
    {
        SceneManager.LoadScene(levelNumber);
        _levelGenerator.Generate(_levels[levelNumber]);
    }
}
