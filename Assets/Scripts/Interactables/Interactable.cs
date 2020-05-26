using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour, IClickable
{
    /*[Header("Sprites")]
    public Sprite buttonPressSprite;
    public Sprite normalSprite;
    public Sprite highlightedSprite;

    [HideInInspector] public SpriteRenderer spriteRenderer;*/
    protected InteractableFSM fsm;

    //public Transform player;

    //[FMODUnity.EventRef]
    //public string NoiseEvent = "";
    //FMOD.Studio.EventInstance noise;

    protected void Awake()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();

        fsm = new InteractableFSM();
        //noise = FMODUnity.RuntimeManager.CreateInstance(NoiseEvent);
    }

    void Start()
    {
        fsm.Initialize(this);

        fsm.AddState(InteractableStateType.Normal, new NormalState());
        fsm.AddState(InteractableStateType.Highlighted, new HighlightedState());
        fsm.AddState(InteractableStateType.Interacting, new InteractingState());

        GotoNormal();
    }

    void Update()
    {
        fsm.UpdateState();
    }

    public void Highlight()
    {
        if (fsm.CurrentStateType==InteractableStateType.Normal)
        {
            Debug.Log("hoi");
            //FMODUnity.RuntimeManager.PlayOneShot(NoiseEvent, transform.position);
            //noise.start();
            GotoHighlighted();
        }
        
    }

    public virtual void HandleInteraction()
    {
        Debug.Log("interacting");
    }

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
