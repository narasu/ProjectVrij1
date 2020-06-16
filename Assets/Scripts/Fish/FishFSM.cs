using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishFSM
{
    public Fish owner { get; private set; }

    private Dictionary<FishStateType, FishState> states;

    public FishStateType CurrentStateType { get; private set; }
    private FishState currentState;
    private FishState previousState;

    public void Initialize(Fish owner)
    {
        this.owner = owner;
        Debug.Log(owner);
        states = new Dictionary<FishStateType, FishState>();
    }

    public void AddState(FishStateType newType, FishState newState)
    {
        states.Add(newType, newState);
        states[newType].Initialize(this);
    }

    public void UpdateState()
    {
        currentState?.Update();
    }

    public void GotoState(FishStateType key)
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

    public FishState GetState(FishStateType type)
    {
        if (!states.ContainsKey(type))
        {
            return null;
        }
        return states[type];
    }
}
