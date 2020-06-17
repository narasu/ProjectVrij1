using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStateType { Play, Pause, Win }

public abstract class GameState
{
    protected GameFSM owner;
    protected GameManager gameManager;

    public void Initialize(GameFSM owner)
    {
        this.owner = owner;
        gameManager = owner.owner;
    }
    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}


public class PlayState : GameState
{
    public override void Enter()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1.0f;
        
    }
    public override void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            
        }*/
    }
    public override void Exit()
    {
        
    }
}
public class PauseState : GameState
{
    public override void Enter()
    {
        //open pause menu, freeze game, unlock cursor
        GameManager.Instance.pauseObject.SetActive(true);
        GameManager.Instance.inGameUI.SetActive(false);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public override void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Escape))
            GameManager.Instance.GotoPlay();
        */
    }
    public override void Exit()
    {
        GameManager.Instance.pauseObject.SetActive(false);
        GameManager.Instance.inGameUI.SetActive(true);
        Time.timeScale = 1f;
    }
}
public class WinState : GameState
{
    public override void Enter()
    {
        GameManager.Instance.winMenuObject.SetActive(true);
        GameManager.Instance.inGameUI.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        Debug.Log("entering win state");
    }
    public override void Update()
    {

    }
    public override void Exit()
    {
        GameManager.Instance.winMenuObject.SetActive(false);
        GameManager.Instance.inGameUI.SetActive(true);
        Time.timeScale = 1f;
        Debug.Log("Exiting win state");
    }
}