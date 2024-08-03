using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject endScreen;
    public GameObject PressE;
    public AudioSource open;
    public AudioSource close;
    private Animator anim;
    private bool canOpen;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (GeneralInfo.currentPlayer != null)
        {
            if (Vector3.Distance(transform.position, GeneralInfo.currentPlayer.transform.position) < 1)
            {
                canOpen = true;
                PressE.SetActive(true);
            }
            else
            {
                canOpen = false;
                PressE.SetActive(false);
            }
        }

        if (GeneralInfo.isGameOver)
        {
            PressE.SetActive(false);
        }
    }

    public  void GoToNextLevel()
    {
        if(canOpen)
        {
            endScreen.SetActive(true);
            GeneralInfo.isGameOver = true;  
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("IsNextToDoor", true);
            open.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("IsNextToDoor", false);
            close.Play();
        }
    }
}
