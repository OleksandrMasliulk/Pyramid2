using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "New Map", menuName = "Map")]
public class MapSO :ScriptableObject {
    [SerializeField] private string _name;
    public string Name => _name;
    [SerializeField] private string _location;
    public string Lcation => _location;
    [SerializeField] private string _info;
    public string Info => _info;
    [SerializeField] private AssetReference _sceneRef;
    public AssetReference SceneReference => _sceneRef;
}
