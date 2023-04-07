using UnityEngine;
using UnityEngine.Events;

public class GameEndWindowsManager : MonoBehaviour
{
    [SerializeField] private GameObject _victoryWindow;
    [SerializeField] private GameObject _gameOverWindow;

    private UnityAction _onVictory;
    private UnityAction _onGameOver;

    private void Start()
    {
        HideAllWindows();
        GameStateMachine.Instance.OnGameOver.AddListener(() => ActivateWindow(_gameOverWindow));
    }

    private void OnEnable()
    {
        _onGameOver += ActivateGameOverWindow;
        _onVictory += ActivateVictoryWindow;
        GameStateMachine.Instance.OnGameOver.AddListener(_onGameOver);
        GameStateMachine.Instance.OnVictory.AddListener(_onVictory);
    }

    private void OnDisable()
    {
        GameStateMachine.Instance.OnGameOver.RemoveListener(_onGameOver);
        GameStateMachine.Instance.OnGameOver.RemoveListener(_onVictory);
    }

    private void ActivateGameOverWindow() => ActivateWindow(_gameOverWindow);
    private void ActivateVictoryWindow() => ActivateWindow(_victoryWindow);
    private void ActivateWindow(GameObject window) => window.SetActive(true);
    private void HideAllWindows()
    {
        _gameOverWindow.SetActive(false);
        _victoryWindow.SetActive(false);
    }
}
