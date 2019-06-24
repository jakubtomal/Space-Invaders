using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int scoreValue = 0;
    [SerializeField] public float startingHealth = 100;
    [SerializeField] public float health = 100;
    [SerializeField] public float shootCounter;
    [SerializeField] public float minTimeBeetweneShots = 0.2f;
    [SerializeField] public float maxTimeBeetweneShots = 3f;
    [SerializeField] public GameObject[] projectiles;
    [SerializeField] public GameObject projectile;
    [SerializeField] public float projectileGravity = 1f;
    [SerializeField] public float projectileStartingSpeed = -5f;
    [SerializeField] public List<GameObject> explosions;
    [SerializeField] public float durationOfExplosion = 1f;

    [Header("Audio")]
    [SerializeField] public AudioClip dethSFX;
    [SerializeField] public AudioClip laserSFX;
    [Range(0,1)][SerializeField] public float dethSFXVolume = 1f;
    [Range(0, 1)] [SerializeField] public float laserSFXVolume = 0.6f;



    // Start is called before the first frame update
    void Start()
    {
        health = startingHealth;
        projectile = projectiles[0];
        shootCounter = Random.Range(minTimeBeetweneShots, maxTimeBeetweneShots);
        
    }

    // Update is called once per frame
    void Update()
    {
        CountDownShoot();
    }

    protected virtual void CountDownShoot()
    {
        shootCounter -= Time.deltaTime;
        if(shootCounter <= 0f)
        {

            shootCounter = Random.Range(minTimeBeetweneShots, maxTimeBeetweneShots);
            Fire();
            
        }
    }

    protected virtual void Fire()
    {
        AudioSource.PlayClipAtPoint(laserSFX, Camera.main.transform.position, laserSFXVolume);
        GameObject currentProjectile = Instantiate(projectile , transform.position,Quaternion.identity) as GameObject;
        currentProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileStartingSpeed);
        currentProjectile.GetComponent<Rigidbody2D>().gravityScale = projectileGravity; ;
        

    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {

        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(other, damageDealer);
    }

    protected virtual void ProcessHit(Collider2D other, DamageDealer damageDealer)
    {
        health -= damageDealer.GetDemage();
        damageDealer.Hit();
        if (health <= 0)
        {
            FindObjectOfType<GameManager>().AddScore(scoreValue);
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log(gameObject);
        int indexOfExplosion = Random.Range(0, explosions.Count);
        GameObject explosion = Instantiate(explosions[indexOfExplosion], transform.position, Quaternion.identity);
        Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(dethSFX, Camera.main.transform.position , dethSFXVolume);
        Destroy(gameObject);
    }

    public void SetProjectile(int index)
    {
        projectile = projectiles[index];
    }
}


