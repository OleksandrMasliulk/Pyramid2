using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SanityFX : MonoBehaviour
{
    [SerializeField] private float blendTime;

    [SerializeField] private Volume sanity100;
    [SerializeField] private Volume sanity75;
    [SerializeField] private Volume sanity50;
    [SerializeField] private Volume sanity25;
    [SerializeField] private Volume sanity0;

    private Volume currentVolume;

    private AudioSource noSanitySound;

    private void Awake()
    {
        currentVolume = sanity100;
    }

    IEnumerator BlendVolumes(Volume newVolume)
    {
        float time = 0f;

        while(time <= blendTime)
        {
            newVolume.weight = Mathf.Lerp(0f, 1f, time / blendTime);
            currentVolume.weight = Mathf.Lerp(1f, 0f, time / blendTime);

            time += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        currentVolume = newVolume;
    }

    public void SetSanity100Volume()
    {
        StopNoSanitySound();
        GameController.Instance.PlayLevelTheme();
        StartCoroutine(BlendVolumes(sanity100));
    }
    public void SetSanity75Volume()
    {
        StopNoSanitySound();
        GameController.Instance.PlayLevelTheme();
        StartCoroutine(BlendVolumes(sanity75));
    }
    public void SetSanity50Volume()
    {
        StopNoSanitySound();
        GameController.Instance.PlayLevelTheme();
        StartCoroutine(BlendVolumes(sanity50));
    }
    public void SetSanity25Volume()
    {
        StopNoSanitySound();
        GameController.Instance.PlayLevelTheme();
        StartCoroutine(BlendVolumes(sanity25));
    }
    public void SetSanity0Volume()
    {
        PlayerNoSanitySound();
        GameController.Instance.PauseLevelTheme();
        StartCoroutine(BlendVolumes(sanity0));
    }

    private void PlayerNoSanitySound()
    {
        if (noSanitySound == null)
        {
            noSanitySound = AudioManager.PlaySound(AudioManager.Sound.NoSanity, true);
        }
    }

    private void StopNoSanitySound()
    {
        if (noSanitySound != null)
        {
            Destroy(noSanitySound.gameObject);
        }
    }
}
