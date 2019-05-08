using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Configuration Parameters
    [Range(1,20)][SerializeField] float moveSpeed;
    [Range(1, 20)] [SerializeField] float speedOfLaser;
    [Range(0, 3)] [SerializeField] float firePeriod;

    [SerializeField] GameObject playerLaser;

    Coroutine fireCoroutine;
    float xMin, xMax, yMin, yMax;
    float width, height;
    // Start is called before the first frame update
    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
        Debug.Log(this.transform.position.x);
        SetUpMoveBoundries();
    }



    void Update()
    {
        Move();
        Fire();
    }

    private void Fire()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        }

        if(Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(fireCoroutine);
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            if (Input.GetButtonUp("Fire1")) break;
            GameObject laser = Instantiate(playerLaser, transform.position, transform.rotation) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speedOfLaser);

            yield return new WaitForSeconds(firePeriod);
        }

        
    }

    private void Move()
    {

        var deltaX = Input.GetAxis("Horizontal");
        var deltaY = Input.GetAxis("Vertical");

        var newPosX = Mathf.Clamp( transform.position.x + deltaX * Time.deltaTime * moveSpeed , xMin + width/2  , xMax - width/2);
        var newPosY = Mathf.Clamp( transform.position.y + deltaY * Time.deltaTime * moveSpeed , yMin + height/2 , yMax - height/2);

        transform.position = new Vector2(newPosX, newPosY);
    }

    private void SetUpMoveBoundries()
    {
        Camera gameCamer = Camera.main;
        xMin = gameCamer.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = gameCamer.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        yMin = gameCamer.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        yMax = gameCamer.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }
}

