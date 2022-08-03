using UnityEngine;
using UnityEngine.AddressableAssets;

public class ArrowTrap : Trap, ISwitchable {
    public ParticleSystem arrows;
    
    [SerializeField] private float _rearmTime;
    private float _lastTimeShooted;
    [SerializeField] private bool _isActive;
    public bool IsActive => _isActive;

    [SerializeField] private AssetReference _soundboardReference;
    private ArrowTrapSoundboardSO _loadedSoundboard;

    private async void Awake() {
        _lastTimeShooted = Time.time;
        _loadedSoundboard = await _soundboardReference.LoadAssetAsyncSafe<ArrowTrapSoundboardSO>();
    }

    private void Shoot() {
        if (_lastTimeShooted + _rearmTime > Time.time)
            return;

        arrows.Play();
        AudioManager.Instance.PlayerSound3D(_loadedSoundboard.ShootSound, transform.position, .3f);
        _lastTimeShooted = Time.time;
    }

    private void OnParticleCollision(GameObject other) {
        Debug.Log("Arrow hit");

        if (other.TryGetComponent<IDamageable>(out IDamageable damagable)) {
            damagable.TakeDamage(1);
        }
    }

    public override void Trigger() {
        if (!IsActive)
            return;

        Shoot();
    }

    public void Activate() => _isActive = true;

    public void Disable() => _isActive = false;
}
