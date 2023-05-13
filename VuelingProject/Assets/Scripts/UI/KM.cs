using TMPro;
using UnityEngine;

namespace UI
{
    public class KM : MonoBehaviour
    {
        public float km;
        public TextMeshProUGUI displayer;
        

        private void Update()
        {
            if (GameManager.Instance.playerStats == null) return;
            km += Time.deltaTime * GameManager.Instance.playerStats.speed;
            displayer.text = "Km: " + (int)km;

        }
    }
}
