using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SanityPostFX : MonoBehaviour
{
    public Volume volume;
    public VolumeProfile sanity100;
    public VolumeProfile sanity75;
    public VolumeProfile sanity50;
    public VolumeProfile sanity25;
    public VolumeProfile sanity0;

    public void SetSanity100Profile()
    {
        volume.profile = sanity100;
    }

    public void SetSanity75Profile()
    {
        volume.profile = sanity100;
    }

    public void SetSanity50Profile()
    {
        volume.profile = sanity100;
    }

    public void SetSanity25Profile()
    {
        volume.profile = sanity100;
    }

    public void SetSanity0Profile()
    {
        volume.profile = sanity100;
    }

    //public void BlendBtwProfiles(VolumeProfile currentProfile, VolumeProfile newProfile)
    //{
    //    currentProfile.components.
    //}
}
