using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : Interactable
{
    
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform playerHand;

    private void FixedUpdate()
    {
        if (rb.isKinematic == true)
        {
            //float dist = Vector3.Distance(rb.position, playerHand.position);
            //rb.position = Vector3.Lerp(rb.position, playerHand.position, dist/2);
            rb.position = playerHand.position;
            rb.rotation = playerHand.rotation;
        }
    }

    //called 
    public override void HandleInteraction()
    {
        base.HandleInteraction();

        


        /*
        if (Player.)
        {
            GotoNormal();
        }*/
    }


    public void Grab()
    {
        rb.isKinematic = true;
        //rb.detectCollisions = false;
    }

    public void Drop()
    {
        rb.isKinematic = false;
        //rb.detectCollisions = true;
    }
    
}
