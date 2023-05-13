using UnityEngine;

namespace GAME
{
    public class ObjectSpawner : MonoBehaviour
    {
        public GameObject player;

        public void Respawn()
        {
            Instantiate(player, transform.position, transform.rotation);
        }
    }
}
