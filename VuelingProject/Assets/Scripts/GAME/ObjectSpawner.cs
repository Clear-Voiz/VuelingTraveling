using System.Collections;
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

        public void SpawnOnSeconds(float time)
        {
            
            StartCoroutine(SpawnOnSecondsCor(time));
        }

        IEnumerator SpawnOnSecondsCor(float delay)
        {
            yield return new WaitForSeconds(delay);
            Respawn();
        }
    }
}
