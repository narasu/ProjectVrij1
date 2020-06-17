using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FishStateType { FishIdle, FishWalking }

public abstract class FishState
{
    protected FishFSM owner;
    protected Fish fish;

    public void Initialize(FishFSM owner)
    {
        this.owner = owner;
        fish = owner.owner;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}

public class FishIdleState : FishState
{
    public override void Enter()
    {
      
    }

    public override void Update()
    {
       
        if (fish.navMeshAgent.velocity != Vector3.zero)
        {
            fish.GotoWalking();
        }
    }

    public override void Exit()
    {
        
    }
}

public class FishWalkingState : FishState
{
    public override void Enter()
    {
      
        fish.walkingSound.PlaySound();
    }

    public override void Update()
    {
        if(fish.navMeshAgent.velocity == Vector3.zero)
        {
            fish.GotoIdle();
        }
      
        
    }

    public override void Exit()
    {
        fish.walkingSound.StopSound();
    }
}