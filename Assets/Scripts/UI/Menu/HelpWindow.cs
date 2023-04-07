using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HelpWindow : MonoBehaviour
{
    [SerializeField] private Button _activateButton;
    [SerializeField] private Button _deactivateButton;
    [SerializeField] private GameObject _helpWindow;
    [SerializeField] private TMP_Text[] _descriptions;

    private void Start()
    {
        _activateButton.onClick.AddListener(ActivateWindow);
        _deactivateButton.onClick.AddListener(DeactivateWindow);
        NormalizeFontSize();
    }

    private void ActivateWindow() => SetWindowState(true);
    private void DeactivateWindow() => SetWindowState(false);
    private void SetWindowState(bool isActive)=> _helpWindow.SetActive(isActive);
    private void NormalizeFontSize()
    {
        float minFontSize = float.MaxValue;
        for (int i = 0; i < _descriptions.Length; i++)
        {
            minFontSize = Mathf.Min(minFontSize, _descriptions[i].fontSize);
            _descriptions[i].enableAutoSizing = false;
        }

        for (int i = 0; i < _descriptions.Length; i++)
            _descriptions[i].fontSize = minFontSize;
    }
}
