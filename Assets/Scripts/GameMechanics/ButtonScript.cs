using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject objToEnable = null;
    public GameObject objToDisable = null;

    public bool isOn = false;
    public AudioSource sound;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || collision.CompareTag("DeadBody") || collision.CompareTag("Object"))
        {
            sound.Play();
            anim.SetBool("IsOn", true);
            isOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("DeadBody") || collision.CompareTag("Object"))
        {
            sound.Play();
            anim.SetBool("IsOn", false);
            isOn = false;
        }
    }

    private void Update()
    {
        if(objToEnable != null && isOn == true)
        {
            objToEnable.SetActive(true);
        }
        if (objToDisable != null && isOn == true)
        {
            objToDisable.SetActive(false);
        }
    }
}
