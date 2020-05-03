using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
    public GameObject mainMenuObject;
    public GameObject pauseObject;
    public GameObject deadMenuObject;
    public GameObject winMenuObject;

    private GameFSM fsm;


    private void Awake()
    {
        fsm = new GameFSM();
        fsm.Initialize();

        instance = FindObjectOfType<GameManager>();
    }

    public void HandlePause()
    {
        if (fsm.CurrentStateType != GameStateType.Pause)
        {
            Debug.Log("Pausing");
            GotoPause();
        }
        else
        {
            fsm.GotoState(fsm.PreviousStateType);
        }
    }

    private void Start()
    {
        GotoMainMenu();
    }

    private void Update()
    {
        fsm.UpdateState();
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

    //Methods for switching to each state
    public void GotoMainMenu()
    {
        fsm.GotoState(GameStateType.MainMenu);
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
    public void GotoDead()
    {
        fsm.GotoState(GameStateType.Dead);
    }

}
