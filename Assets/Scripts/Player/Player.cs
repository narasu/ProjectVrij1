using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [HideInInspector] public int worldState { get; private set; } // 0 for normal world, 1 for camera world

    private PlayerFSM fsm;
    

    private Interactable lookingAt;
    private Movable inHand;


    private CharacterController charController;
    [SerializeField] private float movementSpeed = 8.0f;
    [HideInInspector] public Vector2 walkVector;
    private Vector3 forwardMovement, rightMovement, movement;

    [Header("Worldswitching")]
    [SerializeField] private GameObject mainWorld;
    [SerializeField] private GameObject altWorld;
    [SerializeField] private Image cameraFlash;

    [Header("Audio")]
    [FMODUnity.EventRef] public string CameraOnEvent = "";
    [FMODUnity.EventRef] public string CameraOffEvent = "";

    FMOD.Studio.EventInstance cameraOn;
    FMOD.Studio.EventInstance cameraOff;

    private void Awake()
    {
        instance = this;
        charController = GetComponent<CharacterController>();

        //setup FSM
        fsm = new PlayerFSM();
        fsm.Initialize(this);
        fsm.AddState(PlayerStateType.FirstPerson, new FirstPersonState());
        fsm.AddState(PlayerStateType.Camera, new CameraState());

        //instantiate sound events for world switching
        cameraOn = FMODUnity.RuntimeManager.CreateInstance(CameraOnEvent);
        cameraOff = FMODUnity.RuntimeManager.CreateInstance(CameraOffEvent);
    }

    private void Start()
    {
        GotoFirstPerson();
    }

    private void Update()
    {
        //update movement vectors based on player input
        float forwardInput = Input.GetAxisRaw("Vertical");
        float horizInput = Input.GetAxisRaw("Horizontal");

        walkVector = new Vector2(horizInput, forwardInput);

        //Input event for switching between worlds
        if (Input.GetKeyDown(KeyCode.E))
        {
            Switch();
        }

        //Input event for interacting with objects
        if (Input.GetMouseButtonDown(0))
        {
            Interact();
        }

        //run update on current state
        fsm.UpdateState();
    }

    public void Jump()
    {
        Debug.Log("Jump");
    }

    //player movement
    public void Walk()
    {
        forwardMovement = transform.forward * walkVector.y;
        rightMovement = transform.right * walkVector.x;

        movement = Vector3.Normalize(forwardMovement + rightMovement) * movementSpeed;
        charController.SimpleMove(movement);
    }

    //mouseDelta is set by Look input event
    public void Look(Vector2 mouseDelta)
    {
        Debug.Log(mouseDelta);
    }

    //gets called on Interact input event. Interact with objects
    public void Interact()
    {
        //does the player have something in hand? if so, drop
        if (inHand != null)
        {
            if (inHand.GetComponent<Rigidbody>()==null)
            {
                ClearHand();
                return;
            }
            inHand.Drop();
            ClearHand();
            return;
        }

        // is the player looking at a valid Interactable target?
        lookingAt = PlayerLook.Instance.GetTarget();
        if (lookingAt == null)
            return;

        //set target to interacting state
        lookingAt.GotoInteracting();

        //is the object movable? if so, grab
        inHand = lookingAt.GetComponent<Movable>();
        if (inHand != null)
        {
            inHand.Grab();
        }
    }

    public void ClearHand()
    {
        inHand = null;
    }

    //Switch between normal and camera state
    public void Switch()
    {
        if (fsm.CurrentStateType == PlayerStateType.FirstPerson)
        {
            cameraOn.start();
            GotoCamera();
            worldState = 1;
            return;
        }
        if (fsm.CurrentStateType == PlayerStateType.Camera)
        {
            cameraOff.start();
            GotoFirstPerson();
            worldState = 0;
            return;
        }
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
