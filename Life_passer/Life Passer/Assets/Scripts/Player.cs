using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float runningSpeed = 10f;
    [SerializeField] float jumpHeight = 15f;

    bool isAlive;

    Rigidbody2D myRigidBody2D;
    Collider2D myCollider2D;
    Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        myCollider2D = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return; }
        Move();
        Jump();
        Die();
    }

    private void Move()
    {

        myRigidBody2D.transform.position += Vector3.right * Time.deltaTime * runningSpeed;
        myAnimator.SetBool("Jump", false);
    }

    private void Jump()

    {
        if (myCollider2D.IsTouchingLayers(LayerMask.GetMask("Foreground")))
        {
            if (Input.GetButtonDown("Jump"))
            {
                myRigidBody2D.velocity = new Vector2(myRigidBody2D.velocity.x, jumpHeight);
                myAnimator.SetBool("Jump", true);
            }           
        }

    }

    private void Die()
    {
        if (myCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            isAlive = false;
            myAnimator.SetTrigger("Death");
            FindObjectOfType<GameSession>().HandleLoseCondition();
        }
    }

    IEnumerator Wait()
    {
        isAlive = false;
        yield return new WaitForSeconds(0.5f);
        isAlive = true;
    }
}
