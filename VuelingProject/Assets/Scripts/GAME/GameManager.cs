using System;
using Plane;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerStats playerStats;
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
        Debug.Log(ps.gameObject);
        playerStats = ps;
        playerStats.gameObject.TryGetComponent(out rb);
        Debug.Log(rb);
        Debug.Log(ps);
    }

    private void OnDisable()
    {
        PlayerStats.OnPlayerSpawn -= GetPlayerStats;
    }
}
