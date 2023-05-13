using GAME;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class EnemySpawnManager : MonoBehaviour
    {
        [HideInInspector] public float spawnRate = 2f;
        public ObjectSpawner[] spawnPoints;
        private Timers tim;

        private void Start()
        {
            tim = new Timers(1);
        }

        private void Update()
        {
            if (GameManager.Instance.playerStats == null) return;
            if (GameManager.Instance.isPlaying == false) return;
            float spawnIncrement = GameManager.Instance.playerStats.speed / 10f;
            Debug.Log(spawnRate-spawnIncrement);
            tim.alarm[0] = tim.Timer(spawnRate - (spawnIncrement), tim.alarm[0], spawnPoints[Random.Range(0,spawnPoints.Length-1)].Respawn);
        }
    }
}
