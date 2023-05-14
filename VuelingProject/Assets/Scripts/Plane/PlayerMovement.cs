using GAME;
using UnityEngine;

namespace Plane
{
    public class PlayerMovement : MonoBehaviour
    {
        public GameObject shot;
        [HideInInspector]public int shoots;
        public int maxShoots;

        private void OnEnable()
        {
            ObjectSpawner.onRestarting += Recharge;
        }

        private void OnDisable()
        {
            ObjectSpawner.onRestarting -= Recharge;
        }

        private void Start()
        {
            shoots = maxShoots;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && shoots >0)
            {
                shoots -= 1;
                Instantiate(shot, transform.position + transform.forward, Quaternion.identity);
            }

        }

        private void Recharge()
        {
            shoots = maxShoots;
        }
    }

    
    
}
