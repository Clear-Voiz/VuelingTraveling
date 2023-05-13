using System;
using UnityEngine;

namespace Plane
{
    public class PlayerStats : MonoBehaviour
    {
        public static event Action<PlayerStats> OnPlayerSpawn;
        public float speed;
        public float baseSpeed;
        public float maxSpeed;
        public float lateralSpeed;
        public float maxLateralSpeed;
        public float lateralSpeedIncreaseRate;

        private void Start()
        {
            OnPlayerSpawn?.Invoke(this);
        }


    }
}
