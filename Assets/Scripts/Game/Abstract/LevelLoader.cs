using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    void Start()
    {
        GameStateMachine.Instance.GenerateLevel();
    }
}
