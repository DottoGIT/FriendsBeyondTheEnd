using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMovement : AbstractMovement
{
    public AudioSource steps;
    public AudioSource jump;
    public AudioSource land;
    private bool isGrounded;

    private void Update()
    {
        if (isGrounded == true)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }
    }

    public override void Move(float xVel)
    {
        if (xVel > 0)
        {
            transform.eulerAngles = new Vector3(0,0,0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        rig.velocity = new Vector3(xVel * Time.deltaTime * MovementSpeed, rig.velocity.y, 0);
        anim.SetBool("isRunning", true);

        if(steps.isPlaying == false && isGrounded == true)
        {
            steps.Play();
        }

    }

    public override void Stop()
    {
        rig.velocity = new Vector3(0, rig.velocity.y, 0);
        anim.SetBool("isRunning", false);
    }

    public override void Jump()
    {
        if (isGrounded)
        {
            rig.velocity = new Vector3(rig.velocity.x, JumpHeight, 0);
            anim.SetTrigger("TakeOff");
            if(jump.isPlaying == false)
            {
                jump.Play();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isGrounded == false)
        {
            if(land.isPlaying == false)
            {
                land.Play();
            }
        }


        if (collision.CompareTag("Ground") || collision.CompareTag("DeadBody"))
        {
            isGrounded = true;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Ground") || collision.CompareTag("DeadBody"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground")|| collision.CompareTag("DeadBody"))
        {
            isGrounded = false;
            anim.SetBool("isJumping", false);
        }
    }

}
