using UnityEngine;

namespace Plane
{
    public class ObstacleMovement : MonoBehaviour
    {
        private PlayerStats _ps;
        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            PlayerStats.OnPlayerSpawn += GetPlayerStats;
        }

        private void Start()
        {
            _ps = GameManager.Instance.playerStats;
        }

        private void FixedUpdate()
        {
            if (_rb == null) return;
            if (_ps == null) return;
            _rb.velocity = Vector3.forward * (-1 * _ps.baseSpeed - _ps.speed);
        }

        private void GetPlayerStats(PlayerStats ps)
        {
            _ps = ps;
        }

        private void OnDisable()
        {
            PlayerStats.OnPlayerSpawn -= GetPlayerStats;
        }
    }
}
