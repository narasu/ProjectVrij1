using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Lock for use in lock-and-key mechanic
public class LockItem : MonoBehaviour
{
    [FMODUnity.EventRef][Tooltip("Sound to play when this object is unlocked")] public string UnlockSoundEvent = "";
    protected FMOD.Studio.EventInstance unlockSound;

    private bool unlocked = false;

    private void Awake()
    {
        unlockSound = FMODUnity.RuntimeManager.CreateInstance(UnlockSoundEvent);
        unlockSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
    }

    //Unlock this item and play its unlock sound
    public void Unlock()
    {
        if (unlocked)
            return;

        unlockSound.start();
        unlocked = true;
    }

    //might have to move this bit to its own class
    //as it is very specific behavior that could break sub-classes 
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
