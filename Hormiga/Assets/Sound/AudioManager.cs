using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    private EventInstance mainTheme;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogError("Found more than one AudioManager in the scene!!!");
            Debug.LogError("Destroying new instance!!!");
            Destroy(this);

        }
        else
        {
            instance = this;
        }

    }

    private void Start()
    {
        mainTheme = CreateEventInstance(FmodEvents.instance.playMainTheme);
        StartMusic();
    }

    public void StartMusic()
    {
        mainTheme.start();
    }

    public void StopMusic()
    {
        mainTheme.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public EventInstance CreateEventInstance(EventReference eventReference) 
    {
        EventInstance newEventInstance = RuntimeManager.CreateInstance(eventReference);
        return newEventInstance;
    }

}
