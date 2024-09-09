using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class QuizStepOnePresenter : BaseUIPresenter<QuizStepOneView>
{
    [Inject]
    private readonly QuizModel _quizModel;
    //public UniTask Hide()
    //{
    //    throw new System.NotImplementedException();
    //}

    public override UniTask Show()
    {
        view.SetQuestion(_quizModel.quizes[0].wrongAnswer);

        return base.Show();
    }
}
