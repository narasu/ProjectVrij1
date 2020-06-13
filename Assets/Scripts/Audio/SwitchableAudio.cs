using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Play an audio event that changes when the player switches between worlds

public class SwitchableAudio : MonoBehaviour
{
    [FMODUnity.EventRef] public string SoundEvent = "";

    [SerializeField] private bool repeat = true;
    [SerializeField] [Tooltip("How long until this audio repeats? (in seconds)")] private float repeatInterval = 0.5f;
    [SerializeField] [Tooltip("Should this audio be allowed to fade out when stopped?")] private bool allowFadeOut = false;
    FMOD.Studio.EventInstance sound;
    FMOD.Studio.PARAMETER_ID soundParameterId;

    private Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        sound = FMODUnity.RuntimeManager.CreateInstance(SoundEvent);

        //depending on settings, play audio once or repeat
        if (!repeat)
        {
            sound.start();
        }
        else 
        {
            StartCoroutine("PlaySoundRepeat");
        }

        //create handle for the event's WorldType parameter

        FMOD.Studio.EventDescription soundEventDescription;
        sound.getDescription(out soundEventDescription);
        FMOD.Studio.PARAMETER_DESCRIPTION soundParameterDescription;
        soundEventDescription.getParameterDescriptionByName("WorldType", out soundParameterDescription);
        soundParameterId = soundParameterDescription.id;
    }
    
    //play sound every repeatInterval
    private IEnumerator PlaySoundRepeat()
    {
        while (true)
        {
            sound.start();
            yield return new WaitForSeconds(repeatInterval);
        }
    }

    void Update()
    {
        Set3DAttributes();

        //update the WorldType parameter
        sound.setParameterByID(soundParameterId, Player.Instance.worldState);
    }

    //set the 3D attributes of the audio event, checking for a rigidbody in the process
    private void Set3DAttributes()
    {
        if (rigidBody==null)
        {
            sound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform));
            return;
        }
        sound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform, rigidBody));
    }

    //fade or hard stop audio depending on settings
    private void OnDestroy()
    {
        if (allowFadeOut)
        {
            sound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
        else
        {
            sound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
        sound.release();
    }
}
