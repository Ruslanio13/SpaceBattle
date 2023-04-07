using UnityEngine;
using UnityEngine.UI;

public class HelpWindow : MonoBehaviour
{
    [SerializeField] private Button _activateButton;
    [SerializeField] private Button _deactivateButton;
    [SerializeField] private GameObject _helpWindow;

    private void Start()
    {
        _activateButton.onClick.AddListener(ActivateWindow);
        _deactivateButton.onClick.AddListener(DeactivateWindow);
    }

    private void ActivateWindow() => SetWindowState(true);
    private void DeactivateWindow() => SetWindowState(false);
    private void SetWindowState(bool isActive) => _helpWindow.SetActive(isActive);
}
