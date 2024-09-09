using UnityEngine;
using NativeWebSocket;
using System;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using Zenject;

public class WebSocketService : ITickable
{
    [Inject]
    private readonly WebConfig _webConfig;
    //public event Action<>

    public WebSocket WebSocket => _webSocket;
    WebSocket _webSocket;

    async public void Connect()
    {
        _webSocket = new WebSocket(_webConfig.webSocketUrl);

        _webSocket.OnOpen += () =>
        {
            Debug.Log("Connection open!");
        };

        _webSocket.OnError += (e) =>
        {
            Debug.Log("Error! " + e);
        };

        _webSocket.OnClose += (e) =>
        {
            Debug.Log("Connection closed!");
        };

        _webSocket.OnMessage += (bytes) =>
        {
            var message = System.Text.Encoding.UTF8.GetString(bytes);
            Debug.Log("OnMessage! " + message);
        };

        //_webSocket.Connect();
        await _webSocket.Connect();
        //await Task.Delay(5000);
        //Debug.Log("Connect");
        //await _webSocket.SendText("StartQuiz");
    }

    async public void CloseConnection()
    {
        if(_webSocket != null) 
        { 
            await _webSocket.Close();
        }
    }

    // Start is called before the first frame update
    async void Start()
    {
        _webSocket = new WebSocket("ws://127.0.0.1:8000/");

        _webSocket.OnOpen += () =>
        {
            Debug.Log("Connection open!");
        };

        _webSocket.OnError += (e) =>
        {
            Debug.Log("Error! " + e);
        };

        _webSocket.OnClose += (e) =>
        {
            Debug.Log("Connection closed!");
        };

        _webSocket.OnMessage += (bytes) =>
        {
            Debug.Log("OnMessage!");
            Debug.Log(bytes);

            //getting the message as a string
            var message = System.Text.Encoding.UTF8.GetString(bytes);
            Debug.Log("OnMessage! " + message);
        };

        // Keep sending messages at every 0.3s
        //InvokeRepeating("SendWebSocketMessage", 0.0f, 0.3f);

        // waiting for messages
        await _webSocket.Connect();
    }

    public void Tick()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        if(_webSocket != null)
        {
            _webSocket.DispatchMessageQueue();
        }
#endif
    }

    async void SendWebSocketMessage()
    {
        if (_webSocket.State == WebSocketState.Open)
        {
            await _webSocket.SendText("plain text message");
        }
    }

    private async void OnApplicationQuit()
    {
        await _webSocket.Close();
    }
}
