using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State2 : BaseState
{
    private Boss boss;

    public State2(Boss boss) : base(boss.gameObject)
    {
        this.boss = boss;
    }
    
    public override void InitializeState()
    {
        boss.minTimeBeetweneShots = 0.2f;
        boss.maxTimeBeetweneShots = 1f;
    }

    public override void Fire()
    {

        AudioSource.PlayClipAtPoint(boss.laserSFX, Camera.main.transform.position, boss.laserSFXVolume);
        GameObject currentProjectile = Instantiate(boss.projectiles[1], boss.transform.position, Quaternion.identity) as GameObject;
        currentProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, boss.projectileStartingSpeed);

    }



}
