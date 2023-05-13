using System;
using UnityEngine;

namespace Enemies
{
    public class EnemyPlaneMovement : MonoBehaviour
    {
        private Rigidbody _rb;
        private float speed = 2f;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            Destroy(gameObject,10f);
        }

        private void FixedUpdate()
        {
            _rb.MovePosition(transform.position +(transform.forward * speed * Time.deltaTime));
        }
    }
}
