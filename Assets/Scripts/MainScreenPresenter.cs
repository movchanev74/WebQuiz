using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MainScreenPresenter : BaseUIPresenter<MainScreenView>
{
    [Inject]
    private readonly WebSocketService _webSocketService;
    [Inject]
    private readonly ViewManager _viewManager;

    public override UniTask Show()
    {
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
        if(message.Equals("StartQuiz"))
        {
            _viewManager.Show<QuizStepOnePresenter>();
        }
        
        Debug.Log("OnMessage! " + message);
    }
}
