using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuizStepOneView : BaseUIView
{
    [SerializeField]
    private TMP_Text _questionText;

    public void SetQuestion(string question)
    {
        _questionText.text = question;
    }
}
