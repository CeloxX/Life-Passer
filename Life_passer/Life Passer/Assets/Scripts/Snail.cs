using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour
{

    [SerializeField] GameObject mucus;
    [SerializeField] GameObject mucusPosition;
    [SerializeField] GameObject parent;

    float mucusCounter = 0.1f;


    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        mucusCounter -= Time.deltaTime;
        if (mucusCounter <= 0f)
        {
            Spawn();
            mucusCounter = 0.5f;
        }
    }

    private void Spawn()
    {
        GameObject mucusSpawned = Instantiate(mucus, mucusPosition.transform.position, transform.rotation) as GameObject;
        mucusSpawned.transform.parent = parent.transform;
        Destroy(mucusSpawned, UnityEngine.Random.Range(1, 4));
    }
}
