using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateMech : MonoBehaviour
{
    public ButtonScript button;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (button.isOn)
        {
            anim.SetBool("Open", true);
        }
        else
        {
            anim.SetBool("Open", false);
        }
    }
}
