using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizStepButtonsView : BaseUIView, IUIInfo
{
    public event Action<int> OnButtonClick;

    [SerializeField]
    private TMP_Text _headerText;
    [SerializeField]
    private TMP_Text _infoText;
    [SerializeField]
    private List<ButtonHighlighter> _buttonHighlighters;

    private void Start()
    {
        for (int i = 0; i < _buttonHighlighters.Count; i++)
        {
            int index = i+1;
            _buttonHighlighters[i].button.onClick.AddListener(() => OnButtonClickHandler(index));
        }
    }

    private void OnDestroy()
    {
        foreach (var btn in _buttonHighlighters)
        {
            btn.button.onClick.RemoveAllListeners();
        }
    }

    private void OnButtonClickHandler(int index)
    {
        OnButtonClick?.Invoke(index);
    }

    public void HighlightButton(Color color, int buttonIndex)
    {
        if (_buttonHighlighters.Count > buttonIndex)
        {
            _buttonHighlighters[buttonIndex].SetHighlightColor(color);
        }
    }

    public void SetHeader(string header)
    {
        _headerText.text = header;
    }
    
    public void SetStepInfo(string info)
    {
        _infoText.text = info;
    }

    public void SetButtonInteractable(bool isInteractable)
    {
        foreach (var btn in _buttonHighlighters)
        {
            btn.button.interactable = isInteractable;
        }
    }
}
