using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(LevelGenerator))]
public class GameStateMachine : MonoBehaviour
{
    [SerializeField] private List<LevelPreset> _levels;

    public static GameStateMachine Instance;
    
    public UnityEvent OnGameOver;
    public UnityEvent OnVictory;
    
    private LevelGenerator _levelGenerator;
    private int _currentLevelNumber;
    
    
    private void Awake()
    {
        if (Instance is null)
            Instance = this;
        else
            Destroy(gameObject);
        
        OnGameOver = new UnityEvent();
        OnVictory = new UnityEvent();
        OnVictory.AddListener(TryUpdateMaxLevel);
        DontDestroyOnLoad(this);
        _levelGenerator = GetComponent<LevelGenerator>();
    }

    private IEnumerator LoadCoroutine(int levelNumber)
    {
        _currentLevelNumber = levelNumber <= _levels.Count ? levelNumber : 1;
        var asyncLoadLevel = SceneManager.LoadSceneAsync("Game", LoadSceneMode.Single);
        while (!asyncLoadLevel.isDone){
            Debug.Log("Loading the Scene"); 
            yield return null;
        }
        _levelGenerator.Generate(_levels[_currentLevelNumber - 1]);
    }

    public void LoadLevel(int levelNumber) => StartCoroutine(LoadCoroutine(levelNumber));
    public void ReloadLevel() => StartCoroutine(LoadCoroutine(_currentLevelNumber));
    public void GoNextLevel()=>  StartCoroutine(LoadCoroutine(_currentLevelNumber + 1)); 

    private void TryUpdateMaxLevel()
    {
        int maxLvl = SaveManager.Instance.loadedSave.MaxReachedLevel;
        SaveManager.Instance.loadedSave.SetMaxReachedLevel(Mathf.Max(maxLvl, _currentLevelNumber + 1));
    }
}
