using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class Boost : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private bool _isBoosting;
        public void OnPointerDown(PointerEventData eventData)
        {
            if (GameManager.Instance.rb == null) return;
            _isBoosting = true;
            StartCoroutine(IncrementSpeed());
        }

        private IEnumerator IncrementSpeed()
        {
            while (GameManager.Instance.playerStats.speed < GameManager.Instance.playerStats.maxSpeed && _isBoosting) 
            {
                GameManager.Instance.playerStats.speed += 10f * Time.deltaTime;
                Debug.Log(GameManager.Instance.playerStats.speed);
                yield return null;
            }
            
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (GameManager.Instance.rb == null) return;
            _isBoosting = false;
            StartCoroutine(DecrementSpeed());
        }
        
        private IEnumerator DecrementSpeed()
        {
            while (GameManager.Instance.playerStats.speed > 0.1f && !_isBoosting)
            {
                float speedAmount = 30f * Time.deltaTime;
                if (GameManager.Instance.playerStats.speed - speedAmount < 0f)
                {
                    GameManager.Instance.playerStats.speed = 0f;
                }
                else
                {
                    GameManager.Instance.playerStats.speed -= speedAmount;
                }
                yield return null;
            }
            
        }
    }
}
