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
    private GameObject musicSlider;
    private GameObject sfxSlider;
    public Sprite OriginalSprite;
    public Sprite BlueOrangeMenuSprite;
    public Sprite PurpleBlueMenuSprite;
    public Sprite PinkOrangeMenuSprite;
    public GameObject ColorMenu;
    public void Start()
    {
        settingsController = false;
        Canvas = GameObject.Find("Canvas");
        settingsCanvas = GameObject.Find("SettingsCanvas");
        colorsCanvas = GameObject.Find("Canva_DaltonicType");
        sfxSlider = GameObject.Find("SFXVolume");
        sfxSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("SFXVolume");
        musicSlider = GameObject.Find("MusicVolume");
        musicSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVolume");
        
        settingsCanvas.SetActive(false);
        colorsCanvas.SetActive(false);
        ColorMenu = GameObject.Find("Menu_6");
        OriginalSprite = ColorMenu.GetComponent<Image>().sprite;
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
        ColorMenu.GetComponent<Image>().sprite = OriginalSprite;
    }

    public void SelectBlueOrange()
    {
        PlayerPrefs.SetString("BGColor", "#29B096");
        PlayerPrefs.SetString("SpykeColor", "#F67126");
        ColorMenu.GetComponent<Image>().sprite = BlueOrangeMenuSprite;
    }

    public void SelectPurpleBlue()
    {
        PlayerPrefs.SetString("BGColor", "#674A56");
        PlayerPrefs.SetString("SpykeColor", "#3F6485");
        ColorMenu.GetComponent<Image>().sprite = PurpleBlueMenuSprite;
    }
    public void SelectPinkOrange()
    {
        PlayerPrefs.SetString("BGColor", "#F4A698");
        PlayerPrefs.SetString("SpykeColor", "#F67126");
        ColorMenu.GetComponent<Image>().sprite = PinkOrangeMenuSprite;
    }

    ///Sliders
    //For volume slider
    public void setMusicVolume()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.GetComponent<Slider>().value);
        Debug.Log(musicSlider.GetComponent<Slider>().value);
    }

    //For volume slider
    public void setSFXVolume()
    {
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.GetComponent<Slider>().value);
        Debug.Log(sfxSlider.GetComponent<Slider>().value);
    }

}
