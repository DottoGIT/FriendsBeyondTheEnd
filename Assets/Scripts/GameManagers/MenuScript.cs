using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public void QuitButton()
    {
        Application.Quit();
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
