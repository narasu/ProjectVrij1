using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Movable : Interactable
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform playerHand;
    [SerializeField] private Transform worldType;

    protected override void Awake()
    {
        base.Awake();
    }

    //called from InteractingState.Update()
    public override void HandleInteraction()
    {
        base.HandleInteraction();

    }

    // layer 9 = in hand. layer 10 = interactable.
    public void Grab()
    {
        gameObject.layer = 9;

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.parent = playerHand;
        transform.localPosition = Vector3.zero;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.useGravity = false;
    }

    public void Drop()
    {
        transform.parent = worldType;
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.None;
        gameObject.layer = 10;
        
    }
    /*
    private void OnEnable()
    {
        rb.useGravity = true;
    }

    private void OnDisable()
    {
        rb.useGravity = false;
    }*/
}
