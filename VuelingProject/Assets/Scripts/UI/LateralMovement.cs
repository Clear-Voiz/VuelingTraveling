using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class LateralMovement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private bool isPressed;
        public int direction;


        public void OnPointerDown(PointerEventData eventData)
        {
            //isPressed = true;
            if (GameManager.Instance.rb == null) return;
            GameManager.Instance.rb.velocity = Vector3.right * direction * GameManager.Instance.playerStats.lateralSpeed;
            //StartCoroutine(HorizontalMovement());
        }

        /*private IEnumerator HorizontalMovement()
        {
            
            
            /*while (GameManager.Instance.playerStats.lateralSpeed < GameManager.Instance.playerStats.maxLateralSpeed && isPressed)
            {
                float increaseAmount = GameManager.Instance.playerStats.lateralSpeedIncreaseRate * Time.deltaTime;
                GameManager.Instance.playerStats.lateralSpeed += increaseAmount;
                if (GameManager.Instance.playerStats.lateralSpeed + increaseAmount >
                    GameManager.Instance.playerStats.maxLateralSpeed)
                {
                    GameManager.Instance.playerStats.lateralSpeed = GameManager.Instance.playerStats.maxLateralSpeed;
                }
                else
                {
                    GameManager.Instance.playerStats.lateralSpeed += increaseAmount;
                }
                GameManager.Instance.rb.velocity = Vector3.right * increaseAmount;
                yield return null;
            }#1#
        }
        */


        public void OnPointerUp(PointerEventData eventData)
        {
            //isPressed = false;
            if (GameManager.Instance.rb == null) return;
            GameManager.Instance.rb.velocity = Vector3.zero;
        }
    }
}
