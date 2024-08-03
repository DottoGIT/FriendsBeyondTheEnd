using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TextAdjuster : MonoBehaviour
{
    public Text text1;
    public Text text2;

    private void Update()
    {
        text1.text = "You've finished level " + SceneManager.GetActiveScene().buildIndex;    
        text2.text = "You've finished level " + SceneManager.GetActiveScene().buildIndex;
    }
}
