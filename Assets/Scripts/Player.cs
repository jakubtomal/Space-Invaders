using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Range(1,20)][SerializeField] float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {

        var deltaX = Input.GetAxis("Horizontal");
        var deltaY = Input.GetAxis("Vertical");

        var newPosX = transform.position.x + deltaX * Time.deltaTime * moveSpeed;
        var newPosY = transform.position.y + deltaY * Time.deltaTime * moveSpeed;

        transform.position = new Vector2(newPosX, newPosY);
    }
}

