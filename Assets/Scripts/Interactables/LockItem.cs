using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Lock for use in lock-and-key mechanic
public class LockItem : MonoBehaviour
{
    [FMODUnity.EventRef][Tooltip("Sound to play when this object is unlocked")] public string UnlockSoundEvent = "";
    protected FMOD.Studio.EventInstance unlockSound;

    protected bool unlocked = false;

    private void Awake()
    {
        unlockSound = FMODUnity.RuntimeManager.CreateInstance(UnlockSoundEvent);
    }

    private void Update()
    {
        unlockSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
    }

    //Unlock this item and play its unlock sound
    public virtual void Unlock()
    {
        if (unlocked)
            return;

        unlockSound.start();

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
