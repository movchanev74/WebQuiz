using System;
using System.Collections.Generic;
using Zenject;

[Serializable]
public struct QuizData
{
    public string rightAnswer;
    public string wrongAnswer;
}

public class QuizModel
{
    [Inject]
    private readonly WebSocketService _webSocketService;

    public List<QuizData> quizes;

    public QuizModel()
    {
        //_viewManager.Show<QuizStepOnePresenter>();
        quizes = new List<QuizData>()
        {
            new QuizData()
            {
                rightAnswer = "rightAnswer",
                wrongAnswer = "wrongAnswer",
            }
        };
    }
}
