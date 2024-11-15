using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSelector1 : MonoBehaviour
{
    
    public void SelectDeutreranopy()
    {
        PlayerPrefs.SetString("BGColor", "#D9534F");
        PlayerPrefs.SetString("SpykeColor", "#5CB85C");
    }
    
    public void SelectTritanopy()
    {
        PlayerPrefs.SetString("SpykeColor", "#59E59A");
    }

    public void SelectProtanopy()
    {
        PlayerPrefs.SetString("SpykeColor", "#C9302C");
    } 
}
