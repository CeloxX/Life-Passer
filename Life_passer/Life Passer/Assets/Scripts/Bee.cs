using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;    
    [SerializeField] GameObject projectalPosition;
    [SerializeField] GameObject parent;   

    [SerializeField] AudioSource myAudioSource;

   
    public void Spawn()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectalPosition.transform.position, Quaternion.identity) as GameObject;
        projectile.transform.parent = parent.transform;        
        myAudioSource.Play();
    }
}
