using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState : MonoBehaviour
{

    protected GameObject gameObject;

    public BaseState(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }
    

    public abstract void Fire();
    public abstract void InitializeState();


}
