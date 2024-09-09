using UnityEngine;
using UnityEngine.UI;

public class QuizView : MonoBehaviour
{
    public Text HeaderText;
    public Text InstructionText;
    public Button[] AnswerButtons;
    public Slider NumberSlider;
    public Text NumberText;
    public Text FeedbackText;

    public void SetHeader(string header)
    {
        HeaderText.text = header;
    }

    public void SetInstruction(string instruction)
    {
        InstructionText.text = instruction;
    }

    public void SetFeedback(string feedback)
    {
        FeedbackText.text = feedback;
    }

    public void SetSliderValue(int value)
    {
        NumberSlider.value = value;
    }

    public void SetNumberText(int number)
    {
        NumberText.text = number.ToString();
    }

    // Подписываемся на события нажатий кнопок
    public void SetButtonListeners(UnityEngine.Events.UnityAction<int> callback)
    {
        for (int i = 0; i < AnswerButtons.Length; i++)
        {
            int index = i;
            AnswerButtons[i].onClick.AddListener(() => callback(index));
        }
    }
}
