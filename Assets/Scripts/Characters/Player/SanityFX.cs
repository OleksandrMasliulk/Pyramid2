using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Threading.Tasks;

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
    private AudioSource lowSanitySound;

    private List<Task> taskList;

    private void Awake()
    {
        currentVolume = sanity100;
        taskList = new List<Task>();
    }

    private async Task BlendVolumes(Volume newVolume)
    {
        if (newVolume == currentVolume)
            return;

        if (taskList.Count > 0)
            await taskList[taskList.Count - 1];

        Volume oldVolume = currentVolume;
        currentVolume = newVolume;

        float time = 0f;
        while(time <= blendTime)
        {
            currentVolume.weight = Mathf.Lerp(0f, 1f, time / blendTime);
            oldVolume.weight = Mathf.Lerp(1f, 0f, time / blendTime);

            time += Time.deltaTime;
            await Task.Yield();
        }
    }

    public void SetSanity100Volume()
    {
        StopLowSanitySound();
        StopNoSanitySound();
        GameController.Instance.PlayLevelTheme();

        taskList.Add(BlendVolumes(sanity100));
    }
    public void SetSanity75Volume()
    {
        StopLowSanitySound();
        StopNoSanitySound();
        GameController.Instance.PlayLevelTheme();

        BlendVolumes(sanity75);
    }
    public void SetSanity50Volume()
    {
        PlayLowSanitySound();
        StopNoSanitySound();
        GameController.Instance.PlayLevelTheme();

        BlendVolumes(sanity50);
    }
    public void SetSanity25Volume()
    {
        PlayLowSanitySound();
        StopNoSanitySound();
        GameController.Instance.PlayLevelTheme();

        BlendVolumes(sanity25);
    }
    public void SetSanity0Volume()
    {
        StopLowSanitySound();
        PlayNoSanitySound();
        GameController.Instance.PauseLevelTheme();

        BlendVolumes(sanity0);
    }

    private void PlayNoSanitySound()
    {
        if (noSanitySound == null)
        {
            //noSanitySound = AudioManager.Instance.PlaySound(AudioManager.Instance.GetSoundBoard<>.NoSanity, true);
        }
    }

    private void StopNoSanitySound()
    {
        if (noSanitySound != null)
        {
            Destroy(noSanitySound.gameObject);
        }
    }

    private void PlayLowSanitySound()
    {
        if (lowSanitySound == null)
        {
            //lowSanitySound = AudioManager.PlaySound(AudioManager.Sound.LowSanity, true);
        }
    }

    private void StopLowSanitySound()
    {
        if (lowSanitySound != null)
        {
            Destroy(lowSanitySound.gameObject);
        }
    }
}
