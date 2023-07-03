using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BaseBehaviour : MonoBehaviour
{
    public int team;

    [SerializeField]
    private EnemySoldier boid;

    public GameObject target { set; get; }

    public BoidFSM state { set; get; }

    public enum BoidFSM //states
    {
        Attack,
        Moving,
        Idle
    }

    // Start is called before the first frame update
    void Start()
    {
        state = BoidFSM.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == BoidFSM.Moving)
        {
            boid.movementState = boid.MoveTo;
        }
        if (state == BoidFSM.Attack)
        {
            boid.movementState = boid.Attack;
        }
        if (state == BoidFSM.Idle)
        {
            boid.movementState = boid.Idle;
        }
    }
}