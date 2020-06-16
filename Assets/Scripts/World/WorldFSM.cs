using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldFSM
{
    public World owner { get; private set; }

    private Dictionary<WorldStateType, WorldState> states;

    public WorldStateType CurrentStateType { get; private set; }
    private WorldState currentState;
    private WorldState previousState;

    public void Initialize(World owner)
    {
        this.owner = owner;
        Debug.Log(owner);
        states = new Dictionary<WorldStateType, WorldState>();
    }

    public void AddState(WorldStateType newType, WorldState newState)
    {
        states.Add(newType, newState);
        states[newType].Initialize(this);
    }

    public void UpdateState()
    {
        currentState?.Update();
    }

    public void GotoState(WorldStateType key)
    {
        if (!states.ContainsKey(key))
        {
            return;
        }

        currentState?.Exit();

        previousState = currentState;
        CurrentStateType = key;
        currentState = states[CurrentStateType];

        currentState.Enter();
    }

    public WorldState GetState(WorldStateType type)
    {
        if (!states.ContainsKey(type))
        {
            return null;
        }
        return states[type];
    }
}
