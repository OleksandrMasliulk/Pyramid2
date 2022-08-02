using UnityEngine;
using UnityEngine.AddressableAssets;

public class PlayerVFXHandler : CharacterVFXHandler  {
    [SerializeField] private ParticleSystem _ghostParticles;
    [SerializeField] private AssetReference _corpseSprite;
    [SerializeField] private SanityFX _sanityFX;
    public SanityFX SanityFX => _sanityFX;

    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private AssetReference _ghostMaterial;
    [SerializeField] private AssetReference _aliveMaterial;

    public void EnableGhostParticles() => _ghostParticles.Play();

    public void DisableGhostParticles() => _ghostParticles.Stop();

    public async void SpawnCorpse() {
        Sprite corpseSprite = await _corpseSprite.LoadAssetAsyncSafe<Sprite>();

        GameObject corpse = Instantiate(new GameObject(), transform.position, Quaternion.identity);
        SpriteRenderer sr = corpse.AddComponent<SpriteRenderer>();
        corpse.transform.localScale *= 2;
        sr.sprite = corpseSprite;
        sr.sortingLayerName = "Characters";
    }

    public async void EnableGhostMaterial() {
        Material material = await _ghostMaterial.LoadAssetAsyncSafe<Material>();
        _renderer.materials[0] = material;
        _aliveMaterial.ReleaseAsset();
    }

    public async void EnableAliveMaterial() {
        Material material = await _aliveMaterial.LoadAssetAsyncSafe<Material>();
        _renderer.materials[0] = material;
        _ghostMaterial.ReleaseAsset();
    }
}
