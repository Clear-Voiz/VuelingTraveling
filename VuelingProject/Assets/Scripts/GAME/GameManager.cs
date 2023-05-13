using System;
using System.Collections.Generic;
using Plane;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerStats playerStats;
    public bool isPlaying;
    [HideInInspector] public Rigidbody rb;

    public Player currentPlayer;
    public string userId;
    public TextMeshProUGUI NameDisplayer;

    public PlaneController currentPlayerController;

    public Button startButton;

    public bool infoLoaded;

    public Dictionary<string, Player> Players = new Dictionary<string, Player>();

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

    public void SetUsername(string username, string id, string color)
    {
        currentPlayer.Username = username;
        currentPlayer.Id = id;
        currentPlayer.Color = color;
    }

    public void ReceiveUsernameFrontend(string parameters)
    {
        UserIdentificator userIdentificator = JsonUtility.FromJson<UserIdentificator>(parameters);
        currentPlayer = new Player(userIdentificator.userId, userIdentificator.userName, userIdentificator.color);
        
        NameDisplayer.text = currentPlayer.Color;
        Debug.Log("Received! " + parameters);
    }
}

public struct UserIdentificator
{
    public string userName;
    public string userId;
    public string color;
}

[System.Serializable]
public struct Player
{
    public string Id { get; set; }

    public string Username { get; set; }
    
    public string Color { get; set; }

    public Player(string id, string username, string color)
    {
        this.Id = id;
        this.Username = username;
        this.Color = color;
        Debug.Log(color);
    }
    
    
}
