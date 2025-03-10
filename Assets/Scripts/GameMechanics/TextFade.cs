﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFade : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
             anim.SetBool("IsInRange", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            anim.SetBool("IsInRange", false);
    }
}
