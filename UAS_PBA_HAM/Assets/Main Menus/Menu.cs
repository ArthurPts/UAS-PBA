using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void goSettingsMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
    }
    public void goMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void goTutorialMenu()
    {
        SceneManager.LoadScene("TutorialMenu");
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
