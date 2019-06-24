using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BiggerButton : MonoBehaviour
{
    [Header("size")]
    [Range(1,2)]public float textIncrese;
    private float originalSize;

    [Header("color")]
    private Color originalColor;
    public Color hightLitedColor;



    private void Start()
    {
        originalSize = GetComponent<TextMeshProUGUI>().fontSize;
        originalColor = GetComponent<TextMeshProUGUI>().color;


    }

    private void OnMouseEnter()
    {
        GetComponent<TextMeshProUGUI>().fontSize *= textIncrese;
        GetComponent<TextMeshProUGUI>().color = hightLitedColor;
    }

    private void OnMouseExit()
    {
        GetComponent<TextMeshProUGUI>().fontSize = originalSize;
        GetComponent<TextMeshProUGUI>().color = originalColor;
    }
}
