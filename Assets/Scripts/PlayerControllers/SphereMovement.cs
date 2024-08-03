using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : AbstractMovement
{
    public override void Jump()
    {
        return;
    }
    public override void Stop()
    {
        return;
    }

    public override void Move(float xVel)
    {
        rig.AddForce(new Vector2(xVel * Time.deltaTime * MovementSpeed, 0));
    }

}
