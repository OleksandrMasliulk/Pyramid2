using UnityEngine;

public class CharacterVFXHandler : MonoBehaviour {
    [SerializeField] private ParticleSystem _stepParticles;
    //public ParticleVFX StepParticles => _stepParticles;
    [SerializeField] private ParticleVFX _damageParticles;
    public ParticleVFX DamageParticles => _damageParticles;

    public async void SpawnParticles(ParticleVFX particles) {
        if (particles == null)
            return;

        if (!particles.CanBeSpawned)
            return;

        GameObject go = await particles.particlesReferece.LoadAssetAsyncSafe<GameObject>();
        ParticleSystem ps = Instantiate(go, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
        particles.LastTimeSpawned = Time.time;
    }

    public void EnableStepParticles() => _stepParticles.Play();

    public void DisableStepParticles() => _stepParticles.Stop();

    protected virtual void ReleaseAssets() {
        DamageParticles.particlesReferece.ReleaseAssetSafe();
    }

    private void OnDestroy() {
        ReleaseAssets();
    }
}
