using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgruondScroller : MonoBehaviour
{
    [SerializeField] float backgroundScroolSpeed;
    Material myMaterial;
    Vector2 offset;


    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        offset = new Vector2(0, backgroundScroolSpeed);
        
    }

    // Update is called once per frame
    void Update()
    {
        myMaterial.mainTextureOffset += offset * Time.deltaTime;
    }
}
