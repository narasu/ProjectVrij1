using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM
{
    private Dictionary<PlayerStateType, PlayerState> states;

    public PlayerStateType CurrentStateType { get; private set; }
    private PlayerState currentState;
    private PlayerState previousState;

    public void Initialize()
    {
        states = new Dictionary<PlayerStateType, PlayerState>();

        states.Add(PlayerStateType.FirstPerson, new FirstPersonState());
        states.Add(PlayerStateType.Focus, new FocusState());
    }

    public void UpdateState()
    {
        currentState?.Update();
    }

    public void GotoState(PlayerStateType key)
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

    public PlayerState GetState(PlayerStateType type)
    {
        if (!states.ContainsKey(type))
        {
            return null;
        }
        return states[type];
    }
}
