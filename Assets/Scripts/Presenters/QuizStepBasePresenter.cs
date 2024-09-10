using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class QuizStepBasePresenter<T> : BaseUIPresenter<T>  where T : class, IUIView, IUIInfo
{
    [Inject]
    private readonly ViewManager viewManager;

    protected StepData stepData;
    protected int currentQuestionIndex;

    protected Type nextStepClass;

    async protected UniTask ShowError(string errorText)
    {
        view.SetStepInfo(errorText);
        await UniTask.Delay(1500);
    }

    protected void NextQuestion()
    {
        currentQuestionIndex++;
        if (stepData.questions.Count == currentQuestionIndex)
        {
            viewManager.Show(nextStepClass);
        }
        else
        {
            UpdateInfo();
        }
    }

    protected virtual void UpdateInfo() { }
}