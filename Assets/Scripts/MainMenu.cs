using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Name of the scene to load when starting a new game
    public string newGameScene;

    // Called when the "New Game" button is pressed
    public void NewGame()
    {
        // Load the specified new game scene
        SceneManager.LoadScene(newGameScene);
    }

    // Called when the "Quit" button is pressed
    public void QuitGame()
    {
        // Quit the application (this won't do anything in the editor)
        Application.Quit();
    }
}
