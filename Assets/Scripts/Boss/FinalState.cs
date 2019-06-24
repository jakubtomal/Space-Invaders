using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalState : BaseState
{
    GameObject currentProjectile;
    private Boss boss;

    public FinalState(Boss boss) : base(boss.gameObject)
    {
        this.boss = boss;
    }

    public override void InitializeState()
    {
        boss.minTimeBeetweneShots = 4f;
        boss.maxTimeBeetweneShots = 5f;
    }


    public override void Fire()
    {

        StartCoroutine(test());
        
        
    }

    public void Bomb()
    {
        Debug.Log("Bomb");
    }

    IEnumerator test()
    {
        Debug.Log("test1");
        yield return new WaitForSeconds(0.1f);
    }






}
