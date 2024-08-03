using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    FixedJoint2D joint;

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<CharacterScript>().Die();
        }
        if (collision.CompareTag("DeadBody") && joint == null && collision.GetComponent<SphereTag>() == null)
        {
                joint = gameObject.AddComponent<FixedJoint2D>();
                joint.connectedBody = collision.GetComponent<Rigidbody2D>();
        }
    }
}
