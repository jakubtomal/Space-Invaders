using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Configuration Parameters
    [Header("player")]
    [Range(1,20)][SerializeField] float moveSpeed;
    [SerializeField] float startHealth = 200f;
    private float health;
    [SerializeField] Image healthBar;

    [Header("projectile")]
    [Range(1, 20)] [SerializeField] float speedOfLaser;
    [Range(0, 3)] [SerializeField] float firePeriod;
    [SerializeField] GameObject playerLaser;
    [SerializeField] GameObject explosion;
    [SerializeField] float durationOfExplosion = 1f;
    [SerializeField] AudioClip dethSFX;
    [SerializeField] AudioClip laserSFX;
    [Range(0, 1)] [SerializeField] float laserSFXVolume = 0.8f;
    [Range(0, 1)] [SerializeField] float dethSFXVolume = 1f;

    Coroutine fireCoroutine;
    float xMin, xMax, yMin, yMax;
    float width, height;

    [SerializeField]SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
        SetUpMoveBoundries();
    }



    void Update()
    {
        Move();
        Fire();
        UpdateHealthBar();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(other, damageDealer);
    }

    private void ProcessHit(Collider2D other, DamageDealer damageDealer)
    {
        health -= damageDealer.GetDemage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameObject explosionIns = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(explosionIns, durationOfExplosion);
        AudioSource.PlayClipAtPoint(dethSFX, Camera.main.transform.position, dethSFXVolume);
        Destroy(gameObject);
        FindObjectOfType<SceneLoader>().LoadGameOverScene();
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
            AudioSource.PlayClipAtPoint(laserSFX, Camera.main.transform.position, laserSFXVolume);
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

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = health / startHealth;
    }
}

