using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    [Header("UI objects")]
    public GameObject pauseObject;
    public GameObject winMenuObject;

    //[SerializeField] private GameObject[] tutorialText = new GameObject[3];

    private GameFSM fsm;

    [HideInInspector] public bool IsPaused { get; private set; }

    private void Awake()
    {
        fsm = new GameFSM();
        fsm.Initialize();

        instance = FindObjectOfType<GameManager>();
    }

    public void HandlePause()
    {
        if (fsm.CurrentStateType == GameStateType.Play)
        {
            IsPaused = true;
            Player.Instance.enabled = false;
            PlayerLook.Instance.enabled = false;
            
            GotoPause();
            return;
        }

        if (fsm.CurrentStateType == GameStateType.Pause)
        {
            IsPaused = false;
            Player.Instance.enabled = true;
            PlayerLook.Instance.enabled = true;
            GotoPlay();
        }
    }

    private void Start()
    {
        GotoPlay();
    }

    private void Update()
    {
        fsm.UpdateState();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HandlePause();
        }
    }
    public void GotoPlay()
    {
        fsm.GotoState(GameStateType.Play);
    }
    public void GotoPause()
    {
        fsm.GotoState(GameStateType.Pause);
    }
    public void GotoWin()
    {
        fsm.GotoState(GameStateType.Win);
    }

    //switch to whatever state the game was previously in
    public void GotoPrevious()
    {
        fsm.GotoState(fsm.PreviousStateType);
    }
}
