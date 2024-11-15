using UnityEngine;
using UnityEngine.SceneManagement;

public class EventSystemMainMenu : MonoBehaviour
{
    private bool settingsController;
    private bool colorsController = false;
    private GameObject Canvas;
    private GameObject settingsCanvas;
    private GameObject colorsCanvas;
    public void Start()
    {
        settingsController = false;
        Canvas = GameObject.Find("Canvas");
        settingsCanvas = GameObject.Find("SettingsCanvas");
        colorsCanvas = GameObject.Find("Canva_DaltonicType");
        settingsCanvas.SetActive(false);
        colorsCanvas.SetActive(false);
    }


    //For button presses
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void endGame() {
        Application.Quit();
    }

    public void toggleSettings()
    {
        settingsController = !settingsController;
        settingsCanvas.SetActive(settingsController);        
    }

    public void toggleColors()
    {
        colorsController = !colorsController;
        colorsCanvas.SetActive(colorsController);
    }
}
