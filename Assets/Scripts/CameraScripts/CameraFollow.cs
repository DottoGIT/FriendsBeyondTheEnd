using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    public float Speed;
    public static float OffsetMultiplier = 2;
    public static Vector3 offset = new Vector3(0,2,-10);
    private static Vector3 semiOffset = offset;

    private void FixedUpdate()
    {

        if (GeneralInfo.currentPlayer != null)
        {
            player = GeneralInfo.currentPlayer.transform;
            Vector3 desiredPosition = player.position + semiOffset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Speed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }

    public static void AdjustOffset(float xVel, float yVel)
    {
        if (yVel == -1)
        {
            semiOffset = new Vector3(xVel * OffsetMultiplier, yVel * OffsetMultiplier, -10);
        }
        else
        {
            semiOffset = new Vector3(xVel * OffsetMultiplier, offset.y, -10);
        }
    }
}
