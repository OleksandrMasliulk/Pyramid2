using UnityEngine;
using UnityEngine.AddressableAssets;

[System.Serializable]
public class ParticleVFX {
    public AssetReference particlesReferece;
    public float LastTimeSpawned {get; set;}
    public bool CanBeSpawned => Time.time + _maxSpawnRate >= LastTimeSpawned;

    [SerializeField] private float _maxSpawnRate;

    public void Init() => LastTimeSpawned = Time.time;
}