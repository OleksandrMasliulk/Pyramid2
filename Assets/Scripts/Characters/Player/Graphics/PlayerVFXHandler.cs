using UnityEngine;
using UnityEngine.AddressableAssets;

public class PlayerVFXHandler : CharacterVFXHandler  {
    [SerializeField] private GameObject _ghostParticles;
    [SerializeField] private AssetReference _corpseSprite;
    [SerializeField] private SanityFX _sanityFX;
    public SanityFX SanityFX => _sanityFX;

    public void EnableGhostParticles() => _ghostParticles.SetActive(true);

    public void DisableGhostParticles() => _ghostParticles.SetActive(false);

    public async void SpawnCorpse() {
        Sprite corpseSprite = await _corpseSprite.LoadAssetAsyncSafe<Sprite>();

        GameObject corpse = Instantiate(new GameObject(), transform.position, Quaternion.identity);
        SpriteRenderer sr = corpse.AddComponent<SpriteRenderer>();
        corpse.transform.localScale *= 2;
        sr.sprite = corpseSprite;
        sr.sortingLayerName = "Characters";
    }
}
