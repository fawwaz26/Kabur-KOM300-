using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlide : MonoBehaviour
{
    public bool isSliding = false;

    public Player PL;

    public Rigidbody2D myRigidBody;

    public Animator anim;

    public BoxCollider2D regularColl;
    public BoxCollider2D slideColl;

    public float slideSpeed = 5f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)||Input.GetKeyDown(KeyCode.DownArrow))
        {
            prefromSlide();
        }
    }

    private void prefromSlide()
    {
        isSliding = true;

        anim.SetBool("IsSlide", true);

        regularColl.enabled = false;
        slideColl.enabled = true;

        StartCoroutine("stopSlide");
    }

    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(0.8f);
        anim.Play("Idle");
        anim.SetBool("IsSlide", false);

        regularColl.enabled = true;
        slideColl.enabled = false;
        isSliding = false;
    }
}
