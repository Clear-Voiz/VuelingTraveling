using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected virtual void DoAction(PlaneController plane)
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlaneController plane = other.gameObject.GetComponent<PlaneController>();
        if (plane != null)
        {
            DoAction(plane);
        }
    }
}
