using System;
using UnityEngine;

namespace Plane
{
    public class ConnectToButton : MonoBehaviour
    {
        public static event Action<Rigidbody> OnCreate;
        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            OnCreate?.Invoke(_rb);
        }
    }
}
