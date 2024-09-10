using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class QuizStepTwoPresenter : QuizStepBasePresenter<QuizStepButtonsView>
{
    [Inject]
    private readonly QuizModel quizModel;

    private readonly float timeToWait = 2.0f;
    private DateTime timer;

    private const string ERROR_TEXT = "Это другая кнопка, попробуй еще раз";
    private const string TIME_ERROR_TEXT = "Попробуй нажать кнопку быстрее";

    public QuizStepTwoPresenter()
    {
        nextStepClass = typeof(QuizStepThreePresenter);
    }

    public override UniTask Show()
    {
        if (quizModel.quizes.Count < 1)
        {
            Debug.LogError("Can not find quiz 2");
            return UniTask.CompletedTask;
        }

        stepData = quizModel.quizes[1];
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

    async private void StartTimer()
    {
        view.SetButtonInteractable(false);
        int buttonIndex = stepData.questions[currentQuestionIndex].rightAnswer - 1;
        view.HighlightButton(Color.green, buttonIndex);
        await UniTask.Delay(1500);
        view.HighlightButton(Color.clear, buttonIndex);
        view.SetButtonInteractable(true);

        timer = DateTime.Now;
    }

    async private void CheckAnswer(int answer)
    {
        if (answer == stepData.questions[currentQuestionIndex].rightAnswer)
        {
            double elapsedSeconds = (DateTime.Now - timer).TotalSeconds;
            Debug.Log(elapsedSeconds);
            if (elapsedSeconds >= timeToWait)
            {
                await ShowError(TIME_ERROR_TEXT);
                UpdateInfo();
            }
            else
            {
                NextQuestion();
            }
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
        StartTimer();
    }
}
