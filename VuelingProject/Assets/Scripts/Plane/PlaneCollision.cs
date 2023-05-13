using System;
using UnityEngine;

public class PlaneCollision : MonoBehaviour
{
    public static event Action OnGameOver;
    public GameObject VFX;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(VFX, transform.position, transform.rotation);
            OnGameOver?.Invoke();
            Debug.Log("invoked");
            GameManager.Instance.ChangeGameState();
            Destroy(gameObject);
        }
    }
}
