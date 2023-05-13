using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class Deboost : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            if (GameManager.Instance.playerStats == null) return;
            float speedToReduce = GameManager.Instance.playerStats.maxSpeed;
            GameManager.Instance.playerStats.speed = (speedToReduce/7f) * -1f;
        }


        public void OnPointerUp(PointerEventData eventData)
        {
            if (GameManager.Instance.playerStats == null) return;
            GameManager.Instance.playerStats.speed = 0f;
        }
    }
}
