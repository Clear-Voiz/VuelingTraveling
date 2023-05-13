using System;
using UnityEngine;

namespace UI
{
    public class ButtonFunctions : MonoBehaviour
    {
        public Rigidbody player;
        public static event Action OnElevate;
        public Canvas gameOver;

        public void HideGameOver()
        {
            gameOver.enabled = false;
        }
    }
}
