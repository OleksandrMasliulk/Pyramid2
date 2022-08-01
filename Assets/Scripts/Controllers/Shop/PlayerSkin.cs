using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "New Skin", menuName = "Shop/New Skin")]
public class PlayerSkin : ScriptableObject {
    [SerializeField] private AssetReference _skin;
    public AssetReference Skin => _skin;
    [SerializeField] private int _cost;
    public int Cost => _cost;
}
