using UI;
using UnityEngine;

namespace Powerups
{
    public class Coiner : MonoBehaviour
    {
        public int value;
        public GameObject vfx;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Instantiate(vfx);
                UIManager.Instance.currency += value;
                UIManager.Instance.currencyDisplayer.text = "Money: " + UIManager.Instance.currency;
                Destroy(gameObject);
            }
        }
    }
}
