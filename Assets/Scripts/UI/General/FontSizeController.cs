using UnityEngine;
using TMPro;

public class FontSizeController : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _texts;

    private void Start()
    {
        NormalizeFontSize();
    }

    private void NormalizeFontSize()
    {
        float minFontSize = float.MaxValue;
        for (int i = 0; i < _texts.Length; i++)
        {
            minFontSize = Mathf.Min(minFontSize, _texts[i].fontSize);
            _texts[i].enableAutoSizing = false;
        }

        for (int i = 0; i < _texts.Length; i++)
            _texts[i].fontSize = minFontSize;
    }
}
