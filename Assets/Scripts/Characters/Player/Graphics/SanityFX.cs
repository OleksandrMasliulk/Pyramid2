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
        AudioManager.Instance.RemoveOverlapTheme(AudioManager.Instance.GetSoundBoard<MusicSoundBoard>().noSanitySFX);
        AudioManager.Instance.RemoveOverlapTheme(AudioManager.Instance.GetSoundBoard<MusicSoundBoard>().lowSanitySFX);
        taskList.Add(BlendVolumes(sanity100));
    }
    public void SetSanity75Volume()
    {
        AudioManager.Instance.RemoveOverlapTheme(AudioManager.Instance.GetSoundBoard<MusicSoundBoard>().noSanitySFX);
        AudioManager.Instance.RemoveOverlapTheme(AudioManager.Instance.GetSoundBoard<MusicSoundBoard>().lowSanitySFX);
        GameController.Instance.PlayLevelTheme();

        BlendVolumes(sanity75);
    }
    public void SetSanity50Volume()
    {
        AudioManager.Instance.RemoveOverlapTheme(AudioManager.Instance.GetSoundBoard<MusicSoundBoard>().noSanitySFX);
        AudioManager.Instance.PlayOverlapTheme(AudioManager.Instance.GetSoundBoard<MusicSoundBoard>().lowSanitySFX);
        GameController.Instance.PlayLevelTheme();

        BlendVolumes(sanity50);
    }
    public void SetSanity25Volume()
    {
        AudioManager.Instance.RemoveOverlapTheme(AudioManager.Instance.GetSoundBoard<MusicSoundBoard>().noSanitySFX);
        GameController.Instance.PlayLevelTheme();

        BlendVolumes(sanity25);
    }
    public void SetSanity0Volume()
    {
        AudioManager.Instance.PlayOverlapTheme(AudioManager.Instance.GetSoundBoard<MusicSoundBoard>().noSanitySFX);
        GameController.Instance.PauseLevelTheme();

        BlendVolumes(sanity0);
    }

}
