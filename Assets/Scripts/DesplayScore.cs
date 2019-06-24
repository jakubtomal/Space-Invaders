using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DesplayScore : MonoBehaviour
{
    private TextMeshProUGUI text;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = gameManager.GetScore().ToString();
    }
}
