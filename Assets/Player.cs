using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D myRigidbody;

    public bool grounded;
    public static bool gameispaused;
    //public LayerMask whatIsGround;

    //private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    public int health = 3;
    public GameObject spawner;
    public GameObject player;
    public GameObject spawner3;


    public GameObject restartDisplay;

    private Collider2D myCollider;

    private Animator myAnimator;


    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
        Time.timeScale = 1f;
        gameispaused = false;
    }

    private void FixedUpdate()
    {
        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);
    }

    private void Update()
    {
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        //if (Input.GetKeyDown(KeyCode.Space)){
        //    if (grounded)
        //    {
        //        myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
        //    }

        //}

        //isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (health <= 0) {
            spawner.SetActive(false);
            player.SetActive(false);
            spawner3.SetActive(false);
            restartDisplay.SetActive(true);
            Time.timeScale = 0f;
            gameispaused = true;
        }

        if (grounded == true && (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.UpArrow)) )
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            myRigidbody.velocity = Vector2.up * jumpForce;
        }



        if ((Input.GetKey(KeyCode.Space)||Input.GetKey(KeyCode.UpArrow)) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                myRigidbody.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space)||Input.GetKeyUp(KeyCode.UpArrow))
        {
            isJumping = false;
        }

        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
        //myAnimator.SetBool("Grounded", grounded);
        myAnimator.SetBool("Grounded", grounded);
    }

    public int getHealth() {
        return health;
    }
}
