using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

namespace UI
{
    public class KM : MonoBehaviour
    {
        public float km;
        public TextMeshProUGUI displayer;


        private void OnEnable()
        {
            PlaneCollision.OnGameOver += SendSignal;
        }
        private void OnDisable()
        {
            PlaneCollision.OnGameOver -= SendSignal;
        }

        private void Update()
        {
            if (GameManager.Instance.playerStats == null) return;
            km += Time.deltaTime * GameManager.Instance.playerStats.speed;
            displayer.text = "Km: " + (int)km;
            
        }

        private void SendSignal()
        {
            StartCoroutine(SendWebRequest());
            
        }

        private IEnumerator SendWebRequest()
        {
             WWWForm form = new WWWForm();
             form.AddField("extraCoins",5);
             form.AddField("punctuation", (int)km);
             UnityWebRequest www = UnityWebRequest.Post("https://hack2023-vueling.onrender.com/api/v1/game/645f555df4e714f53fbfeae9", form);
             yield return www.SendWebRequest();

             if (www.result != UnityWebRequest.Result.Success)
             {
                 Debug.Log(www.error);
             }
             else
             {
                 Debug.Log("Form upload complete!");
                 km = 0f;
             }
             //yield return www.SendWebRequest();
        }
    }
}
