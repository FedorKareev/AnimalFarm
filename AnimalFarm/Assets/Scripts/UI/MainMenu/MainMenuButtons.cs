using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void NewGameButton()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
