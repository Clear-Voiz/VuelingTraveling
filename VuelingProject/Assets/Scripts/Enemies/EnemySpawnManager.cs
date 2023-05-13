using System;
using System.Collections.Generic;
using GAME;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class EnemySpawnManager : MonoBehaviour
    {
        [HideInInspector] public float spawnRate = 3f;
        public ObjectSpawner[] spawnPoints;
        private Timers tim;

        private void Start()
        {
            tim = new Timers(1);
        }

        private void Update()
        {
            tim.alarm[0] = tim.Timer(spawnRate, tim.alarm[0], spawnPoints[Random.Range(0,spawnPoints.Length-1)].Respawn);
        }
    }
}
