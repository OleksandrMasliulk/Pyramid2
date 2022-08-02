using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SanityFX : MonoBehaviour {
    [SerializeField] private float blendTime;
    [SerializeField]private Volume _volume;

    private Queue<IEnumerator> _blendQueue = new Queue<IEnumerator>();
    private bool _isBusy;

    private void Awake() {
        //_blendQueue = 
        _isBusy = false;
    }

    private void Update() {
        if (_blendQueue.Count <= 0 || _isBusy)
            return;

        IEnumerator blend = _blendQueue.Dequeue();
        StartCoroutine(blend);
    }

    private IEnumerator SetVignetteCoroutine(float newValue) {
        Vignette vignette = null;
        if (_volume.profile.TryGet<Vignette>(out Vignette v)) 
            vignette = v;

        _isBusy = true;
        float time = 0f;
        float currentIntensity = vignette.intensity.value;
        while (time <= blendTime) {
            vignette.intensity.value = Mathf.Lerp(currentIntensity, newValue, time / blendTime);
            time += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        vignette.intensity.value = newValue;
        _isBusy = false;
    }

    public void SetVignette(float value) => _blendQueue.Enqueue(SetVignetteCoroutine(value));

    public void ShowTentacles() {
    }

    public void HideTentacles() {
    }
}
