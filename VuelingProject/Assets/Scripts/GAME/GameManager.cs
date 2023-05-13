using System;
using System.Collections.Generic;
using Plane;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using Newtonsoft.Json;

public class GameManager : MonoBehaviour
{
    public PlayerStats playerStats;
    public bool isPlaying;
    [HideInInspector] public Rigidbody rb;

    public string myUsername;
    public int myGameId;
    public string myColor;
    public string userId;
    public TextMeshProUGUI NameDisplayer;

    public PlaneController currentPlayerController;

    public Button startButton;

    public bool infoLoaded;

    public List<int> Players = new List<int>();

    public List<string> AvailableColors = new List<string>()
    {
        "FF5732",
        "FFE533",
        "B5FF33",
        "FD33FF"
    };

    public static GameManager Instance { get; private set; }
    public static event Action<PlayerStats> OnPlayerStats;

    private void OnEnable()
    {
        PlayerStats.OnPlayerSpawn += GetPlayerStats;
    }

    private void Awake()
    {
        Instance = this;
        ReceiveUsernameFrontend("{\"userName\": \"dani\", \"userId\": \"aeuaoeu\", \"color\": \"ff0000\"}");
        startButton = GameObject.Find("Start_btn").GetComponent<Button>();
        startButton.interactable = true;
        //Username = ReceiveUsernameFrontend("{\"userName\": \"dani\", \"userId\": \"aeuaoeu\"}");
    }

    private void GetPlayerStats(PlayerStats ps)
    {
        playerStats = ps;
        playerStats.gameObject.TryGetComponent(out rb);
    }

    public void ChangeGameState()
    {
        isPlaying = !isPlaying;
    }

    public void SetLoaded(bool loaded)
    {
        infoLoaded = loaded;
        startButton.interactable = loaded;
    }

    private void OnDisable()
    {
        PlayerStats.OnPlayerSpawn -= GetPlayerStats;
    }

    public void ReceiveUsernameFrontend(string parameters)
    {
        UserIdentificator userIdentificator = JsonConvert.DeserializeObject<UserIdentificator>(parameters);

        userId = userIdentificator.userId;
        myUsername = userIdentificator.userName;
        myColor = userIdentificator.color;
        
        NameDisplayer.text = myColor;
        Debug.Log("Received! " + parameters);
    }
}

public struct UserIdentificator
{
    public string userName;
    public string userId;
    public string color;
}
