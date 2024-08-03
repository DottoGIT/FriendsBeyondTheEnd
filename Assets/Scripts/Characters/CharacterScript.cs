using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public PhysicsMaterial2D DeathMaterial;
    
    public AudioSource death2;
    public AudioSource death3;
    private AbstractMovement movement;
    private Rigidbody2D rig;
    private Animator anim;

    private void Start()
    {
        GeneralInfo.ChangePlayer(gameObject);
        rig = GetComponent<Rigidbody2D>();
        movement = GetComponent<AbstractMovement>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(transform.position.y < -13)
        {
            Die();
        }
    }

    public void Die()
    {
        int rng = Random.Range(0, 2);
        switch (rng)
        {
            case 0:
                death3.Play();
                break;
            case 1:
                death2.Play();
                break;
        }

        anim.SetTrigger("Die");
        rig.sharedMaterial = DeathMaterial;

    }

    public void DisableLifeFunctions()
    {
        Destroy(movement);
        gameObject.tag = "DeadBody";
        Destroy(this);
    }
}
