using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishbowl : LockItem
{
    [SerializeField] private float unlockDelay = 1.0f;
    private float timer = 0f;
    private bool won = false;

    protected override void Update()
    {
        base.Update();
        if (unlocked && !won)
        {
            timer += Time.deltaTime;

            if (timer > unlockDelay)
            {
                GameManager.Instance.GotoWin();
                won = true;
            }
        }

    }
}
