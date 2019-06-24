using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State1 : BaseState
{
    MonoBehaviour monoBehaviour;
    private Boss boss;

    public State1(Boss boss) : base(boss.gameObject)
    {
        this.boss = boss;
    }

    public override void InitializeState()
    {
        boss.minTimeBeetweneShots = 0.5f;
        boss.maxTimeBeetweneShots = 3f;
}

    public override void Fire()
    {
        
        AudioSource.PlayClipAtPoint(boss.laserSFX, Camera.main.transform.position, boss.laserSFXVolume);
        GameObject currentProjectile;

        for (float i = 1; i < 21; i++)
        {
            
            
            currentProjectile = Instantiate(boss.projectiles[0], boss.transform.position,Quaternion.Euler(new Vector3(0,0,360/20*i))) as GameObject;

            currentProjectile.GetComponent<Rigidbody2D>().velocity = currentProjectile.transform.up * 10;
        }

    }



}
