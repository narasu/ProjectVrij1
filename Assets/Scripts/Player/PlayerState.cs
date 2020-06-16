using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStateType { Idle, Walking }

public abstract class PlayerState
{
    protected PlayerFSM owner;
    protected Player player;

    public void Initialize(PlayerFSM owner)
    {
        this.owner = owner;
        player = owner.owner;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}

public class IdleState : PlayerState
{
    public override void Enter()
    {
        
    }

    public override void Update()
    {
        if (player.forwardInput!=0 || player.horizInput!=0)
        {
            player.GotoWalking();
        }
    }

    public override void Exit()
    {
        
    }
}

public class WalkingState : PlayerState
{
    public override void Enter()
    {
        player.footsteps.PlaySound();
    }

    public override void Update()
    {
        if(player.forwardInput==0 && player.horizInput==0)
        {
            player.GotoIdle();
        }
        player.Walk();
        
    }

    public override void Exit()
    {
        player.footsteps.StopSound();
    }
}