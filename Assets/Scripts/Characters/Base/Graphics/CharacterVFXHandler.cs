using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;

public class CharacterVFXHandler : MonoBehaviour
{
    [SerializeField] private GameObject _stepParticles;
    //public ParticleVFX StepParticles => _stepParticles;
    [SerializeField] private ParticleVFX _damageParticles;
    public ParticleVFX DamageParticles => _damageParticles;

    public async void SpawnParticles(ParticleVFX particles)
    {
        if (particles == null)
            return;

        if (!particles.CanBeSpawned)
            return;

        GameObject go = await particles.particlesReferece.LoadAssetAsyncSafe<GameObject>();
        ParticleSystem ps = Instantiate(go, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
        particles.lastTimeSpawned = Time.time;

        await Task.Delay((int)(ps.main.duration * 1000));
        Addressables.ReleaseInstance(go);
    }

    public void EnableStepParticles()
    {
        _stepParticles.SetActive(true);
    }

    public void DisableStepParticles()
    {
        _stepParticles.SetActive(false);
    }
}
