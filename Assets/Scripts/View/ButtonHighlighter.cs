using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHighlighter : MonoBehaviour
{
    [SerializeField]
    private Image _highlightImageBackground;
    [SerializeField]
    private Button _button;

    public Button button => _button;

    public void SetHighlightColor(Color color)
    {
        _highlightImageBackground.color = color;
    }
}
