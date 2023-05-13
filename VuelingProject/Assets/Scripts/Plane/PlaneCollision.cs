using System;
using UnityEngine;

public class PlaneCollision : MonoBehaviour
{
    public static event Action OnGameOver;
    public string objectTag;
    public GameObject VFX;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(objectTag))
        {
            Instantiate(VFX, transform.position, transform.rotation);
            OnGameOver?.Invoke();
            Destroy(gameObject);
        }
    }
}
