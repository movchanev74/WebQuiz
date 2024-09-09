using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUIView : MonoBehaviour, IUIView
{
    public virtual UniTask Hide()
    {
        gameObject.SetActive(false);
        return UniTask.CompletedTask;
    }

    public virtual UniTask Show()
    {
        gameObject.SetActive(true);
        return UniTask.CompletedTask;
    }
}
