using UnityEngine;
using UnityEngine.AddressableAssets;

public class CharacterBaseStatsSO : ScriptableObject {
    [SerializeField] private string _name;
    public string Name => _name;
    [SerializeField] private AssetReference _icon;
    public AssetReference Icon => _icon;
    [SerializeField] private AssetReference _spawnPrefab;
    public AssetReference SpawnPrefab => _spawnPrefab;

    [SerializeField] private float _movementSpeed;
    public float MovementSpeed => _movementSpeed;
}
