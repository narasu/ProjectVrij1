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
            GotoPause();
            return;
        }
        if (fsm.CurrentStateType == GameStateType.Pause)
        {
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

    //Start the scene (this method is called from UI onclick)
    public void StartLevel()
    {
        //instantiate dynamic objects, set positions etc etc etc
    }

    //End the scene
    public void EndLevel()
    {
        //reset positions, deactivate/destroy objects, return to initial state, etc etc etc
    }
    /*
    public void EnableText(TutorialText t)
    {

    }
    */
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
