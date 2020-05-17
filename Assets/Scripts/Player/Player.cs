using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

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

    [SerializeField] private GameObject mainWorld;
    [SerializeField] private GameObject altWorld;

    public bool interacting = false;

    private CharacterController charController;
    [SerializeField] private float movementSpeed = 8.0f;

    public Vector2 walkVector;

    private void Awake()
    {
        //instance = FindObjectOfType<Player>();
        instance = this;
        charController = GetComponent<CharacterController>();

        fsm = new PlayerFSM();
        fsm.Initialize(this);

        fsm.AddState(PlayerStateType.FirstPerson, new FirstPersonState());
        fsm.AddState(PlayerStateType.Camera, new CameraState());

        //InputManager.Instance.controls.FirstPerson.Enable();
    }

    private void Start()
    {
        GotoFirstPerson();
    }

    private void Update()
    {
        fsm.UpdateState();
    }

    public void Jump()
    {
        Debug.Log("Jump");
    }

    public void Walk()
    {
        //transform.Translate(movement);

        Vector3 forwardMovement = transform.forward * walkVector.y;
        Vector3 rightMovement = transform.right * walkVector.x;

        Vector3 movement = Vector3.Normalize(forwardMovement + rightMovement) * movementSpeed;
        charController.SimpleMove(movement);

    }

    public void Look(Vector2 mouseDelta)
    {
        Debug.Log(mouseDelta);

    }

    public void EnableMainWorld()
    {
        mainWorld.SetActive(true);
        altWorld.SetActive(false);
    }

    public void EnableAltWorld()
    {
        mainWorld.SetActive(false);
        altWorld.SetActive(true);
    }

    public void GotoFirstPerson()
    {
        fsm.GotoState(PlayerStateType.FirstPerson);
    }
    public void GotoCamera()
    {
        fsm.GotoState(PlayerStateType.Camera);
    }
}
