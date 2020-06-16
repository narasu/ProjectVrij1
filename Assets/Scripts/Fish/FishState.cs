using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FishStateType { Idle, Walking }

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

public class IdleState : FishState
{
    public override void Enter()
    {
        
    }

    public override void Update()
    {
        if (fish.forwardInput!=0 || fish.horizInput!=0)
        {
            fish.GotoWalking();
        }
    }

    public override void Exit()
    {
        
    }
}

public class WalkingState : FishState
{
    public override void Enter()
    {
        fish.footsteps.PlaySound();
    }

    public override void Update()
    {
        if(fish.forwardInput==0 && fish.horizInput==0)
        {
            fish.GotoIdle();
        }
        fish.Walk();
        
    }

    public override void Exit()
    {
        fish.footsteps.StopSound();
    }
}