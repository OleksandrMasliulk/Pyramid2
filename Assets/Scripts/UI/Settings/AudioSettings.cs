using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;
using UnityEngine.Audio;

public class AudioSettings : Settings
{
    //public float MasterVolume { get; set; }
    //public float SoundVolume { get; set; }
    //public float MusicVolume { get; set; }

    //public AudioSettings()
    //{
    //    MasterVolume = 0f;
    //    SoundVolume = 0f;
    //    MusicVolume = 0f;
    //}

    //public override void ApplySettings()
    //{
        
    //}

    //public async override void LoadProjectSettings()
    //{
    //    var op = Addressables.LoadAssetAsync<AudioMixer>("");
    //    op.Completed += (mixer) =>
    //    {
    //        AudioMixer m = mixer.Result;
    //        m.GetFloat("MasterVolume", out float master);
    //        m.GetFloat("MusicVolume", out float music);
    //        m.GetFloat("SoundVolume", out float sound);

    //        MasterVolume = master;
    //        SoundVolume = sound;
    //        MusicVolume = music;
    //    };

    //    await op.Task;
    //}
}
