using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D myRigidbody;

    public bool grounded;
    //public LayerMask whatIsGround;

    //private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    private Collider2D myCollider;

    private Animator myAnimator;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        myRigidbody.velocity = new Vector2 (moveSpeed, myRigidbody.velocity.y);

        //if (Input.GetKeyDown(KeyCode.Space)){
        //    if (grounded)
        //    {
        //        myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
        //    }

        //}

        //isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (grounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            myRigidbody.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                myRigidbody.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
        //myAnimator.SetBool("Grounded", grounded);
        myAnimator.SetBool("Grounded", grounded);
    }
}
