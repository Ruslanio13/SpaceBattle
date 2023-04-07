using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public class LevelButton : MonoBehaviour
{
    [SerializeField] private int _levelNumber;
    [SerializeField] private TMP_Text text;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        text.text = _levelNumber.ToString();
        button.onClick.AddListener(() => GameStateMachine.Instance.LoadLevel(_levelNumber));
    }
}
