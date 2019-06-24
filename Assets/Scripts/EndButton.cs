using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndButton : MonoBehaviour
{


    private void Start()
    {

        StartCoroutine(YouStupidoBurako());


    }

    private IEnumerator YouStupidoBurako()
    {

        yield return new WaitForSeconds(6);
        GetComponent<TextMeshProUGUI>().text = "You Stupido Burako";
    }

   
}
