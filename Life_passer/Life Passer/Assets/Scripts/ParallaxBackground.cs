using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] Vector2 parallaxMovementMultiplier;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;


    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;      
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxMovementMultiplier.x, deltaMovement.y * parallaxMovementMultiplier.y, 0);
        lastCameraPosition = cameraTransform.position;        
    }
}
