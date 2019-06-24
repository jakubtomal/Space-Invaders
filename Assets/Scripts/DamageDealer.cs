using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{

    [SerializeField] int damage = 100;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Hit();
    }

    public int GetDemage()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
    

}
