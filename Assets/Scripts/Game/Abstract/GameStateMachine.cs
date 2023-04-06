using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameStateMachine : MonoBehaviour
{
    [SerializeField] private List<GameObject> _levels;
    public static GameStateMachine Instance;

    public UnityEvent OnGameOver;
    private void Awake()
    {
        Instance ??= this;
        OnGameOver = new UnityEvent();
        DontDestroyOnLoad(this);
    }

    public void LoadLevel(int levelNumber)
    {
        SceneManager.LoadScene(levelNumber);
        Instantiate(_levels[levelNumber]);
    }
}
