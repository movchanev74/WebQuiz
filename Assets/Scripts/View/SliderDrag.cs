using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderDrag : MonoBehaviour, IPointerUpHandler
{
    public event Action<float> OnEndDrag;

    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void OnPointerUp(PointerEventData data)
    {
        OnEndDrag?.Invoke(slider.value);
    }
}