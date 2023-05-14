using GAME;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class EnemySpawnManager : MonoBehaviour
    {
        [HideInInspector] public float spawnRate = 2f;
        public ObjectSpawner[] spawnPoints;

        private float timeToSpawn;
        private int spawnPoint;

        private void Start()
        {
            spawnPoint = Random.Range(0, spawnPoints.Length - 1);
            timeToSpawn = spawnRate;
        }

        private void Update()
        {
            if (GameManager.Instance.playerStats == null) return;
            if (GameManager.Instance.isPlaying == false) return;

            timeToSpawn -= Time.deltaTime;
            if (timeToSpawn <= 0)
            {
                NewSpawn();
            }
            
            //tim.alarm[0] = tim.Timer(spawnRate - (spawnIncrement), tim.alarm[0], spawnPoints[Random.Range(0,spawnPoints.Length-1)].Respawn);
        }

        void NewSpawn()
        {
            spawnPoints[spawnPoint].Respawn();
            float spawnIncrement = GameManager.Instance.playerStats.speed / GameManager.Instance.playerStats.maxSpeed;
            timeToSpawn = spawnRate - spawnIncrement;
            spawnPoint = Random.Range(0, spawnPoints.Length);
        }
    }
}
