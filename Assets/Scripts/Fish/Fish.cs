using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Fish : MonoBehaviour
{
    private static Fish instance;
    public static Fish Instance
    {
        get
        {
            return instance;
        }
    }

    private FishFSM fsm;

    public Transform Player;
    [HideInInspector] public NavMeshAgent navMeshAgent;

    [HideInInspector] public OneWorldAudio walkingSound;

    private void Awake()
    {
        //Initialize variables;
        instance = this;

        walkingSound = GetComponent<OneWorldAudio>();

        navMeshAgent = GetComponent<NavMeshAgent>();
        //setup FSM
        fsm = new FishFSM();
        fsm.Initialize(this);
        fsm.AddState(FishStateType.FishIdle, new FishIdleState());
        fsm.AddState(FishStateType.FishWalking, new FishWalkingState());
    }

    private void Start()
    {
        
        GotoIdle();
    }

    private void Update()
    {
        
        navMeshAgent.SetDestination(Player.position);

        //run update on current state
        fsm.UpdateState();
    }

  


    //player movement
    public void Walk()
    {
        //NAV MESH AGENT SET DESTINATION + TRANSFORM
        
    }
   

    public void GotoIdle()
    {
        fsm.GotoState(FishStateType.FishIdle);
    }
    public void GotoWalking()
    {
        fsm.GotoState(FishStateType.FishWalking);
    }
}
