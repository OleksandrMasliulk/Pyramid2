using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Settings
{
    //Graphics settings
    public SerializableResolution Resolution { get; set; }
    public int GraphicsQuality { get; set; }
    public FullScreenMode Mode { get; set; }

    //Audio Settings
    public float MasterVolume { get; set; }
    public float SoundVolume { get; set; }
    public float MusicVolume { get; set; }

    //Game settings
    public int Language { get; set; }

    public Settings()
    {
        //Default settings
        Resolution = new SerializableResolution(800, 600);
        GraphicsQuality = 1;
        Mode = FullScreenMode.Windowed;

        MasterVolume = 0f;
        SoundVolume = 0f;
        MusicVolume = 0f;

        Language = 0;
    }
}
