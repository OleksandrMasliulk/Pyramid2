using UnityEngine;
using UnityEngine.AddressableAssets;

[System.Serializable]
public class ParticleVFX
{
    public AssetReference particlesReferece;
    [SerializeField] private float _maxSpawnRate;
    public float lastTimeSpawned;
    public bool CanBeSpawned => Time.time + _maxSpawnRate >= lastTimeSpawned;

    public void Init()
    {
        lastTimeSpawned = Time.time;
    }
}