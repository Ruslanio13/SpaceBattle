using UnityEngine;
using UnityEngine.Events;

public class GameStateMachine : MonoBehaviour
{
    public static GameStateMachine Instance;

    public UnityEvent OnGameOver;
    private void Awake()
    {
        Instance ??= this;
        OnGameOver = new UnityEvent();
    }
}
