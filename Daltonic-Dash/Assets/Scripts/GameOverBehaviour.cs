using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverBehaviour : MonoBehaviour
{
    public void LoadMainMenu()
    {
        AudioManager.instance.PlaySoundButton();
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        AudioManager.instance.PlaySoundButton();
        Application.Quit();
    }   
}
