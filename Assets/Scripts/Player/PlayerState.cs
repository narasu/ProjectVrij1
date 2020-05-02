using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStateType { FirstPerson, Focus }

public abstract class PlayerState
{
    
    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}

public class FirstPersonState : PlayerState
{
    public override void Enter()
    {
        InputManager.Instance.controls.FirstPerson.Enable();
    }

    public override void Update()
    {
        
    }

    public override void Exit()
    {
        InputManager.Instance.controls.FirstPerson.Disable();
    }
}

public class FocusState : PlayerState
{
    public override void Enter()
    {

    }

    public override void Update()
    {

    }

    public override void Exit()
    {

    }
}