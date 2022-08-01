using UnityEngine;

[System.Serializable]
public class Settings {
    public SerializableResolution Resolution { get; set; }
    public int GraphicsQuality { get; set; }
    public FullScreenMode Mode { get; set; }

    public float MasterVolume { get; set; }
    public float SoundVolume { get; set; }
    public float MusicVolume { get; set; }

    public int Language { get; set; }

    public Settings() {
        Resolution = new SerializableResolution(800, 600);
        GraphicsQuality = 1;
        Mode = FullScreenMode.Windowed;

        MasterVolume = 0f;
        SoundVolume = 0f;
        MusicVolume = 0f;

        Language = 0;
    }
}
