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
            if (instance == null)
                instance = FindObjectOfType<Player>();

            return instance;
        }
    }

    private PlayerFSM fsm;

    private Controls controls;

    private void Awake()
    {
        fsm = new PlayerFSM();
        fsm.Initialize();

        controls = InputManager.Instance.controls;

        controls.FirstPerson.Walk.performed += ctx => Walk();
        controls.FirstPerson.Jump.performed += ctx => Jump();

        // controls.Focus.***.performed += ctx => ***();
    }

    private void Jump()
    {
        Debug.Log("Jump");
    }

    private void Walk()
    {
        Vector2 movement = controls.FirstPerson.Walk.ReadValue<Vector2>();
        transform.Translate(movement);
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
