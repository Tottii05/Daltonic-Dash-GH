using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventSystemMainMenu : MonoBehaviour
{
    private bool settingsController = false;
    private GameObject Canvas;
    private GameObject settingsCanvas;
    public void Start()
    {
        settingsController = false;
        Canvas = GameObject.Find("Canvas");
        settingsCanvas = GameObject.Find("SettingsCanvas");
        settingsCanvas.SetActive(false);
    }


    //For button presses
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void endGame() {
        //EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void openSettings()
    {
        settingsController = !settingsController;
        settingsCanvas.SetActive(!settingsController);
        settingsCanvas.SetActive(settingsController);
        
    }
}
