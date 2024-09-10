using System;
using System.Collections.Generic;
using Zenject;

[Serializable]
public struct StepData
{
    public string headerText;
    public List<QuestionData> questions;
}

[Serializable]
public struct QuestionData
{
    public string questionText;
    public int rightAnswer;
}

public class QuizModel
{
    public List<StepData> quizes;

    public QuizModel(DiContainer diContainer)
    {
        var quizesMockConfig = diContainer.TryResolve<QuizesMockConfig>();
        if(quizesMockConfig)
        {
            quizes = quizesMockConfig.quizes;
        }
    }
}
