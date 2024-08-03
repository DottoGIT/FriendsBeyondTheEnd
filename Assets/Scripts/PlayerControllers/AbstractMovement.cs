using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMovement : MonoBehaviour
{
    public int MovementSpeed;
    public int JumpHeight;

    protected Rigidbody2D rig;
    protected Animator anim;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public abstract void Move(float xVel);
    public abstract void Stop();
    public abstract void Jump();
}
