using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sting : MonoBehaviour
{
    [SerializeField] GameObject destroyVFX;
    [SerializeField] Collider2D myCollider;
    [SerializeField] Rigidbody2D myRigidbody;

    private void Start()
    {
        myRigidbody.velocity = new Vector2(-Random.Range(2, 4), 0);
    }
    void Update()
    {
        
        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Foreground")))
        {
            GameObject myVFX = Instantiate(destroyVFX, transform.position, transform.rotation);
            Destroy(myVFX, 0.5f);
            Destroy(gameObject);
        }
    }
}
