using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickUpSFX;
    [SerializeField] GameObject coinPickupVFX;
    [SerializeField] int pointsForCoinPickup = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameSession.Instance.AddToScore(pointsForCoinPickup);
        AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
        GameObject myVFX = Instantiate(coinPickupVFX, transform.position, transform.rotation);
        Destroy(myVFX, 0.5f);
        Destroy(gameObject);
    }
}
