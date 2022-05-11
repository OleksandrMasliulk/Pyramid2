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

    private void Start()
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
        currentVolume.weight = 0f;
        newVolume.weight = 1f;

        currentVolume = newVolume;
    }

    public void SetSanity100Volume()
    {
        StartCoroutine(BlendVolumes(sanity100));
    }
    public void SetSanity75Volume()
    {
        StartCoroutine(BlendVolumes(sanity75));
    }
    public void SetSanity50Volume()
    {
        StartCoroutine(BlendVolumes(sanity50));
    }
    public void SetSanity25Volume()
    {
        StartCoroutine(BlendVolumes(sanity25));
    }
    public void SetSanity0Volume()
    {
        StartCoroutine(BlendVolumes(sanity0));
    }
}
