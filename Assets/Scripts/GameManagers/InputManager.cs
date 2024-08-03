using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static AbstractMovement playerMovement;

    private void Update()
    {

        if (GeneralInfo.currentPlayer != null && GeneralInfo.isGameOver == false)
        {
            playerMovement = GeneralInfo.currentPlayer.GetComponent<AbstractMovement>();

            float xVel = Input.GetAxisRaw("Horizontal");
            float yVel = Input.GetAxisRaw("Vertical");

            if (playerMovement != null)
            {

                if (xVel != 0)
                {
                    playerMovement.Move(xVel);
                }
                else
                {
                    playerMovement.Stop();
                }

                if (yVel == 1)
                {
                    playerMovement.Jump();
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    FindObjectOfType<DoorController>().GoToNextLevel();
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GeneralInfo.currentPlayer.GetComponent<CharacterScript>().Die();
                }

                CameraFollow.AdjustOffset(xVel, yVel);
            }
        }
    }

}
