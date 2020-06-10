using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockItem : MonoBehaviour
{
    [FMODUnity.EventRef] public string UnlockSoundEvent = "";
    FMOD.Studio.EventInstance unlockSound;

    private bool unlocked = false;
    private void Awake()
    {
        
    }

    public void Unlock()
    {
        if (unlocked)
            return;

        unlockSound = FMODUnity.RuntimeManager.CreateInstance(UnlockSoundEvent);
        unlockSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        unlockSound.start();
        Debug.Log("Unlocked");
        unlocked = true;
    }

    private void OnDisable()
    {
        if (unlockSound.isValid())
        {
            unlockSound.setPaused(true);
        }
    }

    private void OnEnable()
    {
        if (unlockSound.isValid())
        {
            unlockSound.setPaused(false);
        }
    }
}
