using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo : MonoBehaviour
{
    [SerializeField] private Vector2 velocidadMovimiento;

    private Vector2 offset;

    private Material material;
    private Color color;

    private void Awake()
    {
        //coger el material del sprite renderer
        material = GetComponent<SpriteRenderer>().material;
        ColorUtility.TryParseHtmlString(PlayerPrefs.GetString("BGColor"), out color);
        material.color = color;
    }

    private void Update()
    {
        offset = velocidadMovimiento * Time.deltaTime;
        material.mainTextureOffset += offset;

    }
     

}
