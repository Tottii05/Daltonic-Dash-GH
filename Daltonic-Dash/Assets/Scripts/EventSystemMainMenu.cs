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
    public void SelectDeutreranopy()
    {
        PlayerPrefs.SetString("BGColor", "#D9534F");
        PlayerPrefs.SetString("SpykeColor", "#5CB85C");
        Debug.Log("esto funcha");
    }

    public void SelectTritanopy()
    { 
        PlayerPrefs.SetString("SpykeColor", "#59E59A");
    }

    public void SelectProtanopy()
    {
        PlayerPrefs.SetString("SpykeColor", "#C9302C");
    }

    ///Sliders
    //For volume slider
    public void setVolume()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.GetComponent<Slider>().value);
    }

}
