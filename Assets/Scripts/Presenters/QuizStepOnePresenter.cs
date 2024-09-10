using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class QuizStepOnePresenter : QuizStepBasePresenter<QuizStepButtonsView>
{
    [Inject]
    private readonly QuizModel quizModel;

    private const string ERROR_TEXT = "Это другая кнопка, попробуй еще раз";

    public QuizStepOnePresenter()
    {
        nextStepClass = typeof(QuizStepTwoPresenter);
    }

    public override UniTask Show()
    {
        if (quizModel.quizes.Count == 0)
        {
            Debug.LogError("Can not find quiz 3");
            return UniTask.CompletedTask;
        }

        stepData = quizModel.quizes[0];
        currentQuestionIndex = 0;        
        UpdateInfo();

        view.SetHeader(stepData.headerText);
        view.OnButtonClick += CheckAnswer;

        return base.Show();
    }

    public override UniTask Hide()
    {
        view.OnButtonClick -= CheckAnswer;

        return base.Hide();
    }

    async private void CheckAnswer(int answer)
    {
        if (answer == stepData.questions[currentQuestionIndex].rightAnswer)
        {
            NextQuestion();
        }
        else
        {
            await ShowError(ERROR_TEXT);
            UpdateInfo();
        }
    }

    protected override void UpdateInfo()
    {
        view.SetStepInfo(stepData.questions[currentQuestionIndex].questionText);
    }
}
