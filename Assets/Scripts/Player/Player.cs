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

    //[HideInInspector] public int worldState { get; private set; } // 0 for normal world, 1 for camera world
    

    private PlayerFSM fsm;
    
    /*    Interactions    */
    //Object the player is looking at
    private Interactable lookingAt;
    //Object of type movable that the player is holding
    [HideInInspector] public Movable inHand;

    /*    Character Movement    */
    private CharacterController charController;
    [SerializeField] private float movementSpeed = 8.0f;
    [HideInInspector] public Vector2 walkVector;
    [HideInInspector] public float forwardInput, horizInput;
    private Vector3 forwardMovement, rightMovement, movement;

    /*    Worldswitching    
    [Header("Worldswitching")]
    [SerializeField] private GameObject mainWorld;
    [SerializeField] private GameObject altWorld;
    [SerializeField] private Image cameraFlash;
    //Fade times for world transition
    [SerializeField] 
    [Range(0f, 2.0f)] 
    [Tooltip("Fade time in seconds")] 
    private float toAltFadeIn, toAltFadeOut, toMainFadeIn, toMainFadeOut;
    private float fadeInTime, fadeOutTime;
    //a variable to store the coroutines that handle worldswitching
    private IEnumerator switchCoroutine;
    [HideInInspector] public bool HasCamera { get => hasCamera; set => hasCamera = value; }
    private bool hasCamera = false;
    
    /*    Audio    
    [Header("Audio")]
    [FMODUnity.EventRef] public string CameraOnEvent = "";
    [FMODUnity.EventRef] public string CameraOffEvent = "";
    FMOD.Studio.EventInstance cameraOn;
    FMOD.Studio.EventInstance cameraOff;
    */
    private bool hasCamera = false;

    //PRess E Tutorial Text (will move to different class later)
    [SerializeField] private GameObject tutorialText;

    [HideInInspector] public SwitchableAudio footsteps;

    private void Awake()
    {
        //Initialize variables;
        instance = this;
        charController = GetComponent<CharacterController>();
        footsteps = GetComponent<SwitchableAudio>();
        //worldState = 0;
        //SetFadeTime();

        //setup FSM
        fsm = new PlayerFSM();
        fsm.Initialize(this);
        fsm.AddState(PlayerStateType.Idle, new IdleState());
        fsm.AddState(PlayerStateType.Walking, new WalkingState());

        //instantiate sound events for world switching
        //cameraOn = FMODUnity.RuntimeManager.CreateInstance(CameraOnEvent);
        //cameraOff = FMODUnity.RuntimeManager.CreateInstance(CameraOffEvent);
    }

    private void Start()
    {
        //GotoFirstPerson();
        GotoIdle();
    }

    private void Update()
    {
        //update movement vectors based on player input
        forwardInput = Input.GetAxisRaw("Vertical");
        horizInput = Input.GetAxisRaw("Horizontal");


        walkVector = new Vector2(horizInput, forwardInput);
        /*
        //Input event for switching between worlds
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inHand!=null)
            {
                inHand.Drop();
            }
            
            switchCoroutine = StartWorldSwitch(fadeInTime, fadeOutTime);
            StartCoroutine(switchCoroutine);
        }
        */

        //Input event for interacting with objects
        if (Input.GetMouseButtonDown(0))
        {
            Interact();
        }

        //run update on current state
        fsm.UpdateState();
    }

    public void GetCamera()
    {
        hasCamera = true;
        tutorialText.SetActive(true);
        StartCoroutine("TextTimer");
    }

    private IEnumerator TextTimer()
    {
        int i = 0;
        while (i==0)
        {
            i++;
            yield return new WaitForSeconds(1.0f);
            tutorialText.SetActive(false);
        }
    }

    //player movement
    public void Walk()
    {
        forwardMovement = transform.forward * walkVector.y;
        rightMovement = transform.right * walkVector.x;

        movement = Vector3.Normalize(forwardMovement + rightMovement) * movementSpeed;
        charController.SimpleMove(movement);
    }

    //Interact with objects
    public void Interact()
    {
        //does the player have something in hand? if so, drop. 
        if (inHand != null)
        {
            if (inHand.GetComponent<Rigidbody>()==null) //check if an object got removed but failed to clear
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


    public void GotoIdle()
    {
        fsm.GotoState(PlayerStateType.Idle);
    }
    public void GotoWalking()
    {
        fsm.GotoState(PlayerStateType.Walking);
    }

    /*
    //Switch between normal and camera state
    public void Switch()
    {
        if (worldState==0)
        {
            GotoCamera();
            worldState = 1;
            return;
        }
        if (worldState==1)
        {
            GotoFirstPerson();
            worldState = 0;
            return;
        }
    }

    //Play the correct audio sample on world switch
    public void SwitchAudio()
    {
        if (worldState == 0)
        {
            cameraOn.start();
            return;
        }
        if (worldState == 1)
        {
            cameraOff.start();
            return;
        }
    }

    //Start world transition fade in
    public IEnumerator StartWorldSwitch(float timeIn, float timeOut)
    {
        //start transition audio
        SwitchAudio();
        
        while (cameraFlash.color.a < 1)
        {
            Color temp = cameraFlash.color;
            temp.a += 0.01f / timeIn;
            cameraFlash.color = temp;
            yield return new WaitForSeconds(0.01f);
        }

        Switch();

        switchCoroutine = EndWorldSwitch(timeOut);
        StartCoroutine(switchCoroutine);
    }

    //World transition fade out
    public IEnumerator EndWorldSwitch(float t)
    {
        while (cameraFlash.color.a > 0)
        {
            Color temp = cameraFlash.color;
            temp.a -= 0.01f / t;
            cameraFlash.color = temp;
            yield return new WaitForSeconds(0.01f);
        }
        SetFadeTime();
    }

    //Update fade times for the world transition based on current world state
    public void SetFadeTime()
    {
        if (worldState == 0)
        {
            fadeInTime = toAltFadeIn;
            fadeOutTime = toAltFadeOut;
            return;
        }

        if (worldState == 1)
        {
            fadeInTime = toMainFadeIn;
            fadeOutTime = toMainFadeOut;
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
    */


}
