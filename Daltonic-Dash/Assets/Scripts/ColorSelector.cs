using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorSelector : MonoBehaviour
{
    public void SetColorPalette(Color color1, Color color2)
    { 
        PlayerPrefs.SetFloat("Color1_R", color1.r);
        PlayerPrefs.SetFloat("Color1_G", color1.g);
        PlayerPrefs.SetFloat("Color1_B", color1.b);

        PlayerPrefs.SetFloat("Color2_R", color2.r);
        PlayerPrefs.SetFloat("Color2_G", color2.g);
        PlayerPrefs.SetFloat("Color2_B", color2.b);

        PlayerPrefs.Save();
    }
}
