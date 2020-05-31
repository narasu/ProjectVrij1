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
        instance = this;
        controls = new Controls();

        controls.FirstPerson.Walk.started += ctx => Player.Instance.walkVector = controls.FirstPerson.Walk.ReadValue<Vector2>();
        controls.FirstPerson.Walk.performed += ctx => Player.Instance.walkVector = controls.FirstPerson.Walk.ReadValue<Vector2>();
        controls.FirstPerson.Walk.canceled += ctx => Player.Instance.walkVector = controls.FirstPerson.Walk.ReadValue<Vector2>();

        controls.FirstPerson.Jump.performed += ctx => Player.Instance.Jump();

        controls.FirstPerson.Look.performed += ctx => PlayerLook.Instance.lookVector = controls.FirstPerson.Look.ReadValue<Vector2>();
        controls.FirstPerson.Look.canceled += ctx => PlayerLook.Instance.lookVector = controls.FirstPerson.Look.ReadValue<Vector2>();

        controls.FirstPerson.Interact.performed += ctx => Player.Instance.Interact();

        controls.FirstPerson.Switch.performed += ctx => Player.Instance.Switch();

        controls.Game.Pause.performed += ctx => GameManager.Instance.HandlePause();
    }

    private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();

    
}
