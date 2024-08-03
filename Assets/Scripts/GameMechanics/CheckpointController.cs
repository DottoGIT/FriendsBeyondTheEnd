using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public bool IsStartCheckpoint = false;

    void Start()
    {
        if (IsStartCheckpoint)
        {
            GeneralInfo.ChangeCheckpoint(this);
        }
    }

    public void Spawn(GameObject obj, GameObject particle)
    {
        Instantiate(particle,transform);
        Instantiate(obj,transform);
    }
}
