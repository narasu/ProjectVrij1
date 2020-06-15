using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WorldStateType { Main, Alt }

public abstract class WorldState
{
    protected WorldFSM owner;
    protected World world;

    public void Initialize(WorldFSM owner)
    {
        this.owner = owner;
        world = owner.owner;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}

public class MainState : WorldState
{
    public override void Enter()
    {
        
        world.EnableMainWorld();
        

    }

    public override void Update()
    {
        
    }

    public override void Exit()
    {
        
    }
}

public class AltState : WorldState
{
    public override void Enter()
    {
        
        world.EnableAltWorld();
    }

    public override void Update()
    {
        
    }

    public override void Exit()
    {
        
    }
}