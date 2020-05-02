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
            if (instance == null)
                instance = FindObjectOfType<InputManager>();

            return instance;
        }
    }

    public Controls controls;

    private void Awake()
    {
        controls = new Controls();
    }

    //private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();

    
}
