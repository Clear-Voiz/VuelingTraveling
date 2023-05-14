using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ExtraSpawner : MonoBehaviour
{
    public List<GameObject> extras;

    private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 5;
    }


    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isPlaying) return;
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        int randType = Random.Range(0, extras.Count);
        Vector3 pos = new Vector3(Random.Range(-10, 10), -0, 22);
        Instantiate(extras[randType]);
        currentTime = Random.Range(5, 10);
    }

   
}
