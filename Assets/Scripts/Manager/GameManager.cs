using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<GameManager>();

            return instance;
        }
    }

    [Header("UI objects")]
    public GameObject mainMenuObject;
    public GameObject pauseObject;
    public GameObject deadMenuObject;
    public GameObject winMenuObject;

    private GameFSM fsm;
    private Controls controls = InputManager.Instance.controls;

    private void Awake()
    {
        fsm = new GameFSM();
        fsm.Initialize();

        //controls.Game.Enable();

        //controls.Game.Pause.performed += ctx => HandlePause();
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

    private void OnDisable()
    {
        //controls.Game.Disable();
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
