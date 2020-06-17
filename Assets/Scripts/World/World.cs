using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class World : MonoBehaviour
{
    private static World instance;
    public static World Instance
    {
        get
        {
            return instance;
        }
    }

    [HideInInspector] public int worldState { get; private set; } // 0 for normal world, 1 for camera world

    /*    Worldswitching    */
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

    private WorldFSM fsm;
    [HideInInspector] public SkyboxManager skyboxManager;

    /*    Audio    */
    [Header("Audio")]
    [FMODUnity.EventRef] public string CameraOnEvent = "";
    [FMODUnity.EventRef] public string CameraOffEvent = "";
    FMOD.Studio.EventInstance cameraOn;
    FMOD.Studio.EventInstance cameraOff;

    private void Awake()
    {
        //Initialize things;
        instance = this;
        worldState = 0;
        SetFadeTime();
        skyboxManager = GetComponent<SkyboxManager>();

        //setup FSM
        fsm = new WorldFSM();
        fsm.Initialize(this);
        fsm.AddState(WorldStateType.Main, new MainState());
        fsm.AddState(WorldStateType.Alt, new AltState());

        //instantiate sound events for world switching
        cameraOn = FMODUnity.RuntimeManager.CreateInstance(CameraOnEvent);
        cameraOff = FMODUnity.RuntimeManager.CreateInstance(CameraOffEvent);
    }

    private void Start()
    {
        GotoMain();
    }

    private void Update()
    {
        //Input event for switching between worlds
        if (Input.GetKeyDown(KeyCode.E) && Player.Instance.HasCamera)
        {
            //make sure the player can't carry objects from one world to another
            // (but what kind of gameplay would be possible if the player could?)
            if (Player.Instance.inHand != null)
            {
                Player.Instance.inHand.Drop();
            }

            switchCoroutine = StartWorldSwitch(fadeInTime, fadeOutTime);
            StartCoroutine(switchCoroutine);
        }

        //run update on current state
        fsm.UpdateState();
    }



    //World transition fade in
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

    //Make the switch between worlds
    public void Switch()
    {
        if (worldState == 0)
        {
            GotoAlt();
            worldState = 1;
            PlayerLook.Instance.camera.fieldOfView = 65;
            TutorialManager.Instance.HideText(Tutorial.E);
            return;
        }
        if (worldState == 1)
        {
            GotoMain();
            worldState = 0;
            PlayerLook.Instance.camera.fieldOfView = 60;
            return;
        }
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
        skyboxManager.ToMainWorld();
    }

    public void EnableAltWorld()
    {
        mainWorld.SetActive(false);
        altWorld.SetActive(true);
        skyboxManager.ToAltWorld();
    }

    public void GotoMain()
    {
        fsm.GotoState(WorldStateType.Main);
    }
    public void GotoAlt()
    {
        fsm.GotoState(WorldStateType.Alt);
    }
}
