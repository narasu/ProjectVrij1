using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Lock for use in lock-and-key mechanic
public class LockItem : MonoBehaviour
{
    [FMODUnity.EventRef][Tooltip("Sound to play when this object is unlocked")] public string UnlockSoundEvent = "";
    protected FMOD.Studio.EventInstance unlockSound;

    private bool unlocked = false;

    //Unlock this item and play its unlock sound
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

    //might have to move this bit to a Record player sub-class
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
