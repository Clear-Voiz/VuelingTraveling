using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    public float lifespan;
    void Start()
    {
        Destroy(gameObject,lifespan);
    }

}
