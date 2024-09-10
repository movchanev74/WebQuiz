using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizStepSliderView : BaseUIView, IUIInfo
{
    public event Action<int> OnSliderValueChanged;

    [SerializeField]
    private TMP_Text _headerText;
    [SerializeField]
    private TMP_Text _infoText;
    [SerializeField]
    private SliderDrag _slider;

    private void Start()
    {
        _slider.OnEndDrag += HandleSliderValueChanged;
    }

    private void OnDestroy()
    {
        _slider.OnEndDrag -= HandleSliderValueChanged;
    }

    private void HandleSliderValueChanged(float value)
    {
        OnSliderValueChanged?.Invoke(Mathf.RoundToInt(value));
    }

    public void SetHeader(string header)
    {
        _headerText.text = header;
    }

    public void SetStepInfo(string info)
    {
        _infoText.text = info;
    }
}
