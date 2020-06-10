using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour, IClickable
{
    protected InteractableFSM fsm;

    //Create FSM
    protected virtual void Awake()
    {
        fsm = new InteractableFSM();
    }

    void Start()
    {
        //Initialize FSM and add states
        fsm.Initialize(this);

        fsm.AddState(InteractableStateType.Normal, new NormalState());
        fsm.AddState(InteractableStateType.Highlighted, new HighlightedState());
        fsm.AddState(InteractableStateType.Interacting, new InteractingState());

        //start in normal state
        GotoNormal();
    }

    void Update()
    {
        fsm.UpdateState();
    }

    //Go to highlighted state, called when player is looking at an interactable object
    public void Highlight()
    {
        if (fsm.CurrentStateType==InteractableStateType.Normal)
        {
            GotoHighlighted();
        }
        
    }

    public virtual void HandleInteraction() {}

    public virtual void GotoNormal()
    {
        fsm.GotoState(InteractableStateType.Normal);
    }
    public virtual void GotoHighlighted()
    {
        fsm.GotoState(InteractableStateType.Highlighted);
    }
    public virtual void GotoInteracting()
    {
        fsm.GotoState(InteractableStateType.Interacting);
    }
}
