using System;
using UI;
using UnityEngine;

namespace Powerups
{
    public class BonusPoints : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
               // UIManager.Instance.currency += 
            }
        }
    }
}
