using Zenject;

public class QuizPresenter
{
    private readonly QuizModel _model;
    private readonly QuizView _view;

    public QuizPresenter(QuizModel model, QuizView view)
    {
        _model = model;
        _view = view;

        _view.SetButtonListeners(OnButtonPressed);
        ShowCurrentStep();
    }

    private void ShowCurrentStep()
    {
        //switch (_model.CurrentScreen)
        //{
        //    case 1:
        //        ShowScreen1();
        //        break;
        //    case 2:
        //        ShowScreen2();
        //        break;
        //    case 3:
        //        ShowScreen3();
        //        break;
        //}
    }

    private void ShowScreen1()
    {
        _view.SetHeader("Обучение управлению, Шаг 1/3");
        //_view.SetInstruction("Нажмите кнопку Вариант ответа №" + (_model.CurrentStep + 1));
        // Логика проверки нажатий кнопок и перехода к следующему шагу
    }

    private void ShowScreen2()
    {
        _view.SetHeader("Обучение управлению, Шаг 2/3");
        _view.SetInstruction("Быстро нажмите кнопку нужного ответа.");
        // Логика для подсветки кнопок и проверки времени реакции
    }

    private void ShowScreen3()
    {
        _view.SetHeader("Обучение управлению, Шаг 3/3");
        _view.SetInstruction("Выбери на шкале нужное значение.");
        // Логика для управления слайдером и проверки правильности введенных чисел
    }

    private void OnButtonPressed(int buttonIndex)
    {
        // Обработка нажатия кнопок и переходы по шагам
    }
}
