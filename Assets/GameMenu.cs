using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoTOMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
