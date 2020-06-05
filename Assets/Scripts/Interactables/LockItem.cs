using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockItem : MonoBehaviour
{

    [FMODUnity.EventRef]
    public string UnlockEvent = "";

    FMOD.Studio.EventInstance unlockEventInstance;

    private bool unlocked = false;

    private void Awake()
    {
        unlockEventInstance = FMODUnity.RuntimeManager.CreateInstance(UnlockEvent);
    }
    public void Unlock()
    {
        if (unlocked)
            return;

        Debug.Log("Unlocked");
        unlockEventInstance.start();
        unlocked = true;
    }
}
