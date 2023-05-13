using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ButtonFunctions : MonoBehaviour
    {
        public Canvas gameOver;
        public Canvas startGame;
        public TextMeshProUGUI username;


        private void OnEnable()
        {
            PlaneCollision.OnGameOver += ShowGameOver;
        }

        private void Start()
        {
            username.text = GameManager.Instance.currentPlayer.Username;
        }

        public void HideGameOver()
        {
            gameOver.gameObject.SetActive(false);
        }
        
        public void HideStartGame()
        {
            startGame.enabled = false;
        }

        public void ShowGameOver()
        {
            gameOver.gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            PlaneCollision.OnGameOver -= ShowGameOver;
        }
    }
}
