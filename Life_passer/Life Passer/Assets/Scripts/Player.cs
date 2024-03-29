using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float runningSpeed = 10f;
    [SerializeField] float jumpHeight = 15f;
    [SerializeField] float jumpDelay = 0.5f;
    [SerializeField] float waitingTimeForMove = 0.5f;
    [SerializeField] GameObject deathVFX;

    bool isAlive;
    float jumpTimer;

    Rigidbody2D myRigidBody2D;
    Collider2D myCollider2D;
    BoxCollider2D myFeetCollider2D;
    Animator myAnimator;
    void Awake()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        myCollider2D = GetComponent<CapsuleCollider2D>();
        myFeetCollider2D = GetComponent<BoxCollider2D>();
        myAnimator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start() =>  StartCoroutine(Wait());
        
    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return; }
        
        if (Input.GetButtonDown("Jump") )
        {
            jumpTimer = Time.time + jumpDelay;
        }

    }

    void FixedUpdate()
    {
        if (!isAlive) { return; }
        Move();
        if (jumpTimer > Time.time && myFeetCollider2D.IsTouchingLayers(LayerMask.GetMask("Foreground")))
        {
            Jump();
        }
        Die();
    }

    private void Move()
    {
        myRigidBody2D.transform.position +=  runningSpeed * Time.deltaTime * new Vector3(1, 0, 0);        
    }



    private void Jump()
    {
        myRigidBody2D.gravityScale = 0;
        myRigidBody2D.velocity = new Vector2(myRigidBody2D.velocity.x, 0);
        myRigidBody2D.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        myAnimator.SetTrigger("Jump");
        myRigidBody2D.gravityScale = 2;
        jumpTimer = 0f;
    }

    private void Die()
    {
        if (myCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            GameObject myVFX = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(myVFX, 0.5f);
            isAlive = false;
            myRigidBody2D.velocity = Vector2.zero;
            myRigidBody2D.isKinematic = true;            
            myAnimator.SetTrigger("Death");
            GameSession.Instance.HandleLoseCondition();
        }
    }

    IEnumerator Wait()
    {
        isAlive = false;
        yield return new WaitForSeconds(waitingTimeForMove);
        isAlive = true;
    }
}
