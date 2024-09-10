using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class QuizStepThreePresenter : QuizStepBasePresenter<QuizStepSliderView>
{
    [Inject]
    private readonly QuizModel _quizModel;

    private const string ERROR_TEXT = "Это неправильное число, попробуй еще раз";

    public QuizStepThreePresenter()
    {
        nextStepClass = typeof(FinalScreenPresenter);
    }

    public override UniTask Show()
    {
        if (_quizModel.quizes.Count < 2)
        {
            Debug.LogError("Can not find quiz 3");
            return UniTask.CompletedTask;
        }

        stepData = _quizModel.quizes[2];
        currentQuestionIndex = 0;

        UpdateInfo();

        view.SetHeader(stepData.headerText);
        view.OnSliderValueChanged += CheckAnswer;    

        return base.Show();
    }

    public override UniTask Hide()
    {
        view.OnSliderValueChanged -= CheckAnswer;

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
        view.SetStepInfo($"{stepData.questions[currentQuestionIndex].questionText} \n {stepData.questions[currentQuestionIndex].rightAnswer}");
    }
}
