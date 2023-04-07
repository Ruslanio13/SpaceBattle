using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public class LevelButton : MonoBehaviour
{
    [SerializeField] private int _levelNumber;
    [SerializeField] private TMP_Text _text;
    private Button _button;

    public void SetLevelButtonActive(bool isInteractable)
    {
        _text.text = _levelNumber.ToString();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => GameStateMachine.Instance.LoadLevel(_levelNumber));
        _text.gameObject.SetActive(isInteractable);
        _button.interactable = isInteractable;
    }
}
