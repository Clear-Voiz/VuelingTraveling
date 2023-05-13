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

		JsonMessage msg = JsonUtility.FromJson<JsonMessage>(message);

		switch (msg.type)
		{
			case "hello":
				int gameId = int.Parse(msg.payload["id"]);
				string list = msg.payload["players"];

				List<Player> players = JsonUtility.FromJson<List<Player>>(list);

				foreach (var p in players)
				{
					GameManager.Instance.Players.Add(p.Id, p);
				}

				Debug.Log("My Id: " + gameId);
				Debug.Log("Players: " + list);
				break;
		}
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

		JsonMessage hello = new JsonMessage("hello", 0, new Dictionary<string, string>());
		await websocket.SendText(JsonUtility.ToJson(hello));
	}

	struct JsonMessage
	{
		public string type { get; set; }
		public int target { get; set; }
		public Dictionary<string, string> payload { get; set; }

		public JsonMessage(string type, int target, Dictionary<string, string> payload)
		{
			this.type = type;
			this.target = target;
			this.payload = payload;
		}
	}
}
