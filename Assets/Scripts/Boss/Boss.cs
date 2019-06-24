using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Boss : Enemy
{

    float timeBeetweneStates = 5f;
    float timer;
    [SerializeField]public BaseState currentState { get; private set; }
    private Dictionary<int, BaseState> aviableStates;

    // Start is called before the first frame update
    void Start()
    {
        health = startingHealth;
        timer = timeBeetweneStates;
        var states = new Dictionary<int, BaseState>()
        {
            { 1, new State1(this) },
            { 2, new State2(this) },
            { 3, new FinalState(this) },

        };

        SetStates(states);
        currentState = aviableStates[UnityEngine.Random.Range(1, 3)];
        currentState.InitializeState();


        shootCounter = UnityEngine.Random.Range(minTimeBeetweneShots, maxTimeBeetweneShots);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        CountDownShoot();
        if (timer <= 0 )
        {
            ChangeCurrentState(aviableStates[UnityEngine.Random.Range(1,3)]);
            currentState.InitializeState();
            timer = timeBeetweneStates;
        }

    }



    protected override void Fire()
    {
        currentState.Fire();
    }

    protected void ChangeCurrentState(BaseState newState)
    {
        currentState = newState;
    }

    public void SetStates(Dictionary<int, BaseState> states)
    {
        aviableStates = states;
    }







}
