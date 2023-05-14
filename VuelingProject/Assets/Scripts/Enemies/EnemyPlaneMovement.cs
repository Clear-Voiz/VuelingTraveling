using UnityEngine;

namespace Enemies
{
    public class EnemyPlaneMovement : MonoBehaviour
    {
        private Rigidbody _rb;
        private float speed = 3f;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            PlaneCollision.OnGameOver += DestroyOnDemand;
        }

        private void Start()
        {
            Destroy(gameObject,10f);
        }

        private void FixedUpdate()
        {
            _rb.MovePosition(transform.position +(transform.forward * speed * Time.deltaTime));
        }

      

        private void DestroyOnDemand()
        {
            Destroy(gameObject);
        }

        private void OnDisable()
        {
            PlaneCollision.OnGameOver -= DestroyOnDemand;
        }
    }
}
