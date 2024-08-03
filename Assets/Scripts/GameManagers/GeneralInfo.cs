using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GeneralInfo
{
    public static GameObject currentPlayer { get; private set; }
    public static CheckpointController currentCheckpoint { get; private set; }
    public static bool isGameOver;

    public static void ChangePlayer(GameObject obj)
    {
        currentPlayer = obj;
    }

    public static void ChangeCheckpoint(CheckpointController obj)
    {
        currentCheckpoint = obj;
    }


}
