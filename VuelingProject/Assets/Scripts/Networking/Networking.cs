using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NativeWebSocket;

public class Networking : MonoBehaviour
{
    public string Username = "playerA";
    WebSocket? websocket;

    // Start is called before the first frame update
   

	private void OnMessage(byte[] data)
	{
		string message = System.Text.Encoding.UTF8.GetString(data);
		Debug.Log("Message received: " + message);
	}

	private void OnOpen()
	{
        Debug.Log("Server connected!");
	}

	// Update is called once per frame
	void Update()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
		websocket?.DispatchMessageQueue();
#endif
	}

	public async void CallServer()
	{
		Debug.Log("Connecting to game server...");

		// Cuando nos queramos conectar varios,
		// ws://178.33.35.235:3000/gateway?username=XXX
		websocket = new WebSocket("ws://127.0.0.1:3000/gateway?username=" + Username);

		websocket.OnOpen += OnOpen;
		websocket.OnMessage += OnMessage;

		await websocket.Connect();
		//websocket.Send()
		
	}
}
