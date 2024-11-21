using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventSystemMainMenu : MonoBehaviour
{
    private bool settingsController;
    private bool colorsController = false;
    private GameObject Canvas;
    private GameObject settingsCanvas;
    private GameObject colorsCanvas;
    private GameObject volumeSlider;
    public void Start()
    {
        settingsController = false;
        Canvas = GameObject.Find("Canvas");
        settingsCanvas = GameObject.Find("SettingsCanvas");
        colorsCanvas = GameObject.Find("Canva_DaltonicType");
        settingsCanvas.SetActive(false);
        colorsCanvas.SetActive(false);

        volumeSlider = GameObject.Find("VolumeSetting");
    }


    ///For button presses
    //Start button
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
    //Quit button
    public void endGame() {
        Application.Quit();
    }

    //Settings button
    public void toggleSettings()
    {
        settingsController = !settingsController;
        settingsCanvas.SetActive(settingsController);
        Canvas.SetActive(!settingsController);
    }

    //Color menu button
    public void toggleColors()
    {
        colorsController = !colorsController;
        colorsCanvas.SetActive(colorsController);
    }

    //Color change buttons in the ColorMenu
    public void SelectGreenRed()
    {
        PlayerPrefs.SetString("BGColor", "#5CB85C");
        PlayerPrefs.SetString("SpykeColor", "#D9534F");
    }

    public void SelectBlueOrange()
    {
        PlayerPrefs.SetString("BGColor", "#29B096");
        PlayerPrefs.SetString("SpykeColor", "#F67126");
    }

    public void SelectPurpleBlue()
    {
        PlayerPrefs.SetString("BGColor", "#674A56");
        PlayerPrefs.SetString("SpykeColor", "#3F6485");
    }
    public void SelectPinkOrange()
    {
        PlayerPrefs.SetString("BGColor", "#F4A698");
        PlayerPrefs.SetString("SpykeColor", "#F67126");
    }

    ///Sliders
    //For volume slider
    public void setVolume()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.GetComponent<Slider>().value);
    }

}
