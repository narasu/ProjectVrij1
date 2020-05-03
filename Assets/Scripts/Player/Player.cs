using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private static Player instance;
    public static Player Instance
    {
        get
        {
            return instance;
        }
    }

    private PlayerFSM fsm;


    private void Awake()
    {
        instance = FindObjectOfType<Player>();

        fsm = new PlayerFSM();
        fsm.Initialize();

        
    }

    public void Jump()
    {
        Debug.Log("Jump");
    }

    public void Walk(Vector2 movement)
    {
        transform.Translate(movement);
    }

    public void Look(Vector2 mouseDelta)
    {
        Debug.Log(mouseDelta);
    }

    private void Start()
    {
        GotoFirstPerson();
    }

    private void Update()
    {
        fsm.UpdateState();
    }

    public void GotoFirstPerson()
    {
        fsm.GotoState(PlayerStateType.FirstPerson);
    }
    public void GotoFocus()
    {
        fsm.GotoState(PlayerStateType.Focus);
    }
}
