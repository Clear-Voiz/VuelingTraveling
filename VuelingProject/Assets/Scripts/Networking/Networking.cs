using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NativeWebSocket;
using Newtonsoft.Json;

public class Networking : MonoBehaviour
{
	public GAME.ObjectSpawner objectSpawner;
	public UI.ButtonFunctions buttonFunctions;

	WebSocket websocket;

	private void OnMessage(byte[] data)
	{
		string message = System.Text.Encoding.UTF8.GetString(data);
		Debug.Log("Message received: " + message);

		JsonMessage msg = JsonConvert.DeserializeObject<JsonMessage>(message);

		switch (msg.type)
		{
			case "hello":
				int gameId = int.Parse(msg.payload["id"]);
				string listJson = msg.payload["players"];

				List<int> players = JsonConvert.DeserializeObject<List<int>>(listJson);

				foreach (var p in players)
				{
					GameManager.Instance.Players.Add(p);
					Debug.Log("Added player Id " + p + " in my game");
				}

				GameManager.Instance.SetLoaded(true); //bajarlo al final del case Hello
				
				objectSpawner.Respawn();
				buttonFunctions.HideStartGame();
				GameManager.Instance.ChangeGameState();

				break;
		}
		// GameManager.Instance.currentPlayerController.SpeedDebuff();
		// GameManager.Instance.currentPlayerController.VisibilityDebuff();
		// GameManager.Instance.currentPlayerController.InvertControllsDebuff();
	}

	private async void OnOpen()
	{
        Debug.Log("Server connected!");

		JsonMessage hello = new JsonMessage("hello", 0, new Dictionary<string, string>());
		string json = JsonConvert.SerializeObject(hello);
		await websocket.SendText(json);
	}

	// Update is called once per frame
	void Update()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
		websocket?.DispatchMessageQueue();
#endif
	}

	public async void StartNetworking()
    {
		Debug.Log("Connecting to game server...");

		// Cuando nos queramos conectar varios,
		// ws://178.33.35.235:3000/gateway?username=XXX
		websocket = new WebSocket("ws://178.33.35.235:3000/gateway?username=" + GameManager.Instance.myUsername);

		websocket.OnOpen += OnOpen;
		websocket.OnMessage += OnMessage;

		await websocket.Connect();
	}

	[System.Serializable]
	struct JsonMessage
	{
		public string type;
		public int target;
		public Dictionary<string, string> payload;

		public JsonMessage(string type, int target, Dictionary<string, string> payload)
		{
			this.type = type;
			this.target = target;
			this.payload = payload;
		}
	}
}
