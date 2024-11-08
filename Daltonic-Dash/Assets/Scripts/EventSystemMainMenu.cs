using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventSystemMainMenu : MonoBehaviour
{
    //For button hovering


    //For button presses
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void endGame() {
        EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void openSettings()
    {
        SceneManager.LoadScene(2);
    }
}
