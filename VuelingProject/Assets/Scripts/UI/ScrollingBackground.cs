using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ScrollingBackground : MonoBehaviour
    {
        [SerializeField] private RawImage background;
        [SerializeField] private float _x;
        [SerializeField] private float _y;

        private void Update()
        {
            if (!GameManager.Instance.isPlaying) return;
            background.uvRect = new Rect(background.uvRect.position + new Vector2(_x, _y) * Time.deltaTime,
                background.uvRect.size);
        }
    }
}
