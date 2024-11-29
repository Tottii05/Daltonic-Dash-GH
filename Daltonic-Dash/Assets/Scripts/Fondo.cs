using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo : MonoBehaviour
{
    [SerializeField] private Vector2 velocidadMovimiento;


    private Material material;
    private Color color;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        ColorUtility.TryParseHtmlString(PlayerPrefs.GetString("BGColor"), out color);
        material.color = color;
    }

    private Vector2 totalOffset = Vector2.zero;

    private void Update()
    {
        totalOffset.x += velocidadMovimiento.x * Time.deltaTime;
        totalOffset.y += velocidadMovimiento.y * Time.deltaTime;
        material.mainTextureOffset = totalOffset;
    }


}
