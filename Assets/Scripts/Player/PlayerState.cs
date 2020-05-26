using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStateType { FirstPerson, Camera }

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

public class FirstPersonState : PlayerState
{
    public override void Enter()
    {
        //InputManager.Instance.controls.FirstPerson.Enable();

        player.EnableMainWorld();
    }

    public override void Update()
    {
        

        player.Walk();
    }

    public override void Exit()
    {
        //InputManager.Instance.controls.FirstPerson.Disable();
    }
}

public class CameraState : PlayerState
{
    public override void Enter()
    {
        //InputManager.Instance.controls.FirstPerson.Enable();

        player.EnableAltWorld();
    }

    public override void Update()
    {
        player.Walk();
    }

    public override void Exit()
    {
        //InputManager.Instance.controls.FirstPerson.Disable();
    }
}