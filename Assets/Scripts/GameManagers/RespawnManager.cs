using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public enum PlayerType
{
    Squere,
    Sphere
}

[System.Serializable]
public class RespawnManager : MonoBehaviour
{
    public GameObject GameOverScreen;
    public GameObject Square;
    public GameObject Sphere;
    public GameObject SphereParticle;
    public GameObject SquareParticle;
    public PlayerType[] arrayRespawn;
    public Queue<PlayerType> respawnQueue = new Queue<PlayerType>();
    public Texture SphereIcon;
    public Texture SquareIcon;
    public RawImage[] IconPlaces;
    public Color transparent;
    public Color notTransparent;

    private void Start()
    {
        foreach(var type in arrayRespawn)
        {
            GeneralInfo.isGameOver = false;
            respawnQueue.Enqueue(type);
        }
    }


    private void Update()
    {
        int iconCount = 0;
        foreach(var type in respawnQueue)
        {
            switch (type)
            {
                case PlayerType.Sphere: IconPlaces[iconCount].texture = SphereIcon;
                    IconPlaces[iconCount].color = notTransparent;
                    break;
                case PlayerType.Squere: IconPlaces[iconCount].texture = SquareIcon;
                    IconPlaces[iconCount].color = notTransparent;
                    break;
            }
            iconCount++;
        }
        for(int x = iconCount; x < 10; x++)
        {
            IconPlaces[x].color = transparent;
        }

        if (FindObjectOfType<CharacterScript>() == false)
        {
            if (respawnQueue.Count > 0)
            {

                PlayerType whatToRespawn = respawnQueue.Dequeue();

                if (whatToRespawn == PlayerType.Sphere)
                {
                    GeneralInfo.currentCheckpoint.Spawn(Sphere,SphereParticle);
                }
                else if (whatToRespawn == PlayerType.Squere)
                {
                    GeneralInfo.currentCheckpoint.Spawn(Square,SquareParticle);
                }
            }
            else
            {
                GeneralInfo.isGameOver = true;
                GameOverScreen.SetActive(true);
            }
        }
    }
}
