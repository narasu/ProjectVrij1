using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance
    {
        get
        {
            return instance;
        }
    }
    public int test = 5;
    public Controls controls;

    private void Awake()
    {
        instance = FindObjectOfType<InputManager>();
        controls = new Controls();

        controls.FirstPerson.Walk.performed += ctx => Player.Instance.Walk(controls.FirstPerson.Walk.ReadValue<Vector2>());
        controls.FirstPerson.Jump.performed += ctx => Player.Instance.Jump();
        controls.FirstPerson.Look.performed += ctx => Player.Instance.Look(controls.FirstPerson.Look.ReadValue<Vector2>());
        // controls.Focus.***.performed += ctx => ***();

        controls.Game.Pause.performed += ctx => GameManager.Instance.HandlePause();
    }

    private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();

    
}
