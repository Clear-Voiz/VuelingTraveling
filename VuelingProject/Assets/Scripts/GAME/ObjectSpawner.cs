using UnityEngine;

namespace GAME
{
    public class ObjectSpawner : MonoBehaviour
    {
        public GameObject player;

        private void Start()
        {
            Respawn();
        }

        public void Respawn()
        {
            Instantiate(player, transform.position, transform.rotation);
        }
    }
}
