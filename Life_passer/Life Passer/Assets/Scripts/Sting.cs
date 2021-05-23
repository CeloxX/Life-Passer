using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sting : MonoBehaviour
{
    [SerializeField] GameObject destroyVFX;
    Collider2D mycollider;
    // Start is called before the first frame update
    void Start()
    {
        mycollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mycollider.IsTouchingLayers(LayerMask.GetMask("Foreground")))
        {


            GameObject myVFX = Instantiate(destroyVFX, transform.position, transform.rotation);
            Destroy(myVFX, 0.5f);
            Destroy(gameObject);

        }
    }
}
