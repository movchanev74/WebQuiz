using UnityEngine;
using NativeWebSocket;
using System;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using Zenject;

public class WebSocketService : ITickable, IDisposable
{
    [Inject]
    private readonly WebConfig _webConfig;
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

        await _webSocket.Connect();
    }

    async public void CloseConnection()
    {
        if(_webSocket != null) 
        { 
            await _webSocket.Close();
        }
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

    private async void OnApplicationQuit()
    {
        await _webSocket.Close();
    }

    public void Dispose()
    {
        CloseConnection();
    }
}
