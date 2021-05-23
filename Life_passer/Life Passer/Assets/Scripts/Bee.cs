using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;    
    [SerializeField] GameObject projectalPosition;
    [SerializeField] GameObject parent;
    

    AudioSource myAudioSource;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    public void Spawn()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectalPosition.transform.position, Quaternion.identity) as GameObject;
        projectile.transform.parent = parent.transform;
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-Random.Range(2, 4), 0);
        myAudioSource.Play();
    }
}
