using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class StartScreenPresenter : BaseUIPresenter<MessageScreenView>
{
    [Inject]
    private readonly WebSocketService _webSocketService;
    [Inject]
    private readonly ViewManager _viewManager;

    private const string START_TEXT = "Ожидаем запуск...";
    private const string START_COMMAND = "StartQuiz";

    public override UniTask Show()
    {
        view.SetMessage(START_TEXT);

        _webSocketService.Connect();
        _webSocketService.WebSocket.OnMessage += OnMessageRecieved;

        return base.Show();
    }

    public override UniTask Hide()
    {
        if (_webSocketService != null && _webSocketService.WebSocket != null)
        {
            _webSocketService.WebSocket.OnMessage -= OnMessageRecieved;
            _webSocketService.CloseConnection();
        }

        return base.Hide();
    }

    private void OnMessageRecieved(byte[] bytes)
    {
        string message = System.Text.Encoding.UTF8.GetString(bytes);
        if(message.Equals(START_COMMAND))
        {
            _viewManager.Show<QuizStepOnePresenter>();
        }
        
        Debug.Log(message);
    }
}
