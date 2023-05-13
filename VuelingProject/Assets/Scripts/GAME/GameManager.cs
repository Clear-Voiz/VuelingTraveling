using System;
using Plane;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerStats playerStats;
    public bool isPlaying;
    [HideInInspector] public Rigidbody rb;
    public static GameManager Instance { get; private set; }
    public static event Action<PlayerStats> OnPlayerStats;
    
    private void OnEnable()
    {
        PlayerStats.OnPlayerSpawn += GetPlayerStats;
    }

    private void Awake()
    {
        Instance = this;
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

    private void OnDisable()
    {
        PlayerStats.OnPlayerSpawn -= GetPlayerStats;
    }
}
