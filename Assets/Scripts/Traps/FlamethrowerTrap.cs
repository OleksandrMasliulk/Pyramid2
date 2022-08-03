using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class FlamethrowerTrap : Trap, ISwitchable {
    [Header("Graphics")]
    [SerializeField] private GameObject _fireGraphics;
    [SerializeField] private ParticleSystem _ps;
    [SerializeField] private ParticleSystem _ps2;

    [Header("Areas of effect")]
    [SerializeField] private ISeeker<IHaveSanity> _sanitySeeker;
    [SerializeField] private ISeeker<IDamageable> _damageSeeker;

    [Header("Trap settings")]
    [SerializeField] private float _rearmTime;
    [SerializeField] private float _flameThrowingDuration;
    private bool _isReady;
    [SerializeField]private bool _isActive;
    public bool IsActive => _isActive;

    private Coroutine _rearmCoroutine;
    private Coroutine _flamethrowingCoroutine;

    [SerializeField] private AssetReference _soundboardReference;
    private FlamethrowerTrapSoundboardSO _loadedSoundboard;

    private async void Awake() {
        _sanitySeeker = GetComponentInChildren<ISeeker<IHaveSanity>>();
        _damageSeeker = GetComponentInChildren<ISeeker<IDamageable>>();
        _loadedSoundboard = await _soundboardReference.LoadAssetAsyncSafe<FlamethrowerTrapSoundboardSO>();
    }

    private void Start() => _flamethrowingCoroutine = StartCoroutine(ThrowFireCoroutine());

    IEnumerator ThrowFireCoroutine() {
        AudioManager.Instance.PlayerSound3D(_loadedSoundboard.ThrowFlameSound, transform.position, _flameThrowingDuration);

        foreach (IHaveSanity s in _sanitySeeker.ObjectsSeeked)
            s.ModifySanity(-sanityLoss);

        EnableGraphics();
        float startThrowingTime = Time.time;
        while (startThrowingTime + _flameThrowingDuration >= Time.time && IsActive) {
            foreach(IDamageable d in _damageSeeker.ObjectsSeeked) {
                d.TakeDamage(1);
                Debug.Log("Flamethrower trap hit");
            }
            yield return new WaitForSeconds(DefaultTickTime);
        }

        if (IsActive)
            _rearmCoroutine = StartCoroutine(RearmCoroutine());
    }

    IEnumerator RearmCoroutine() {
        DisableGraphics();

        _isReady = false;
        yield return new WaitForSeconds(_rearmTime);
        _isReady = true;

        if (IsActive)
            _flamethrowingCoroutine = StartCoroutine(ThrowFireCoroutine());
    }

    private void EnableGraphics() {
        _fireGraphics.SetActive(true);
        _ps.Play();
        _ps2.Play(); 
    }

    private void DisableGraphics() {
        _fireGraphics.SetActive(false);
        _ps.Stop();
        _ps2.Stop();
    }

    public override void Trigger() {
    }

    public void Activate() {
        _isActive = true;

        if (_isReady) {
            if (_rearmCoroutine != null)
                StopCoroutine(_rearmCoroutine);
            _flamethrowingCoroutine = StartCoroutine(ThrowFireCoroutine());
        }
        else {
            if (_rearmCoroutine == null)
                _rearmCoroutine = StartCoroutine(RearmCoroutine());
        }
            
    }

    public void Disable() {
        _isActive = false;

        if (_flamethrowingCoroutine != null)
            StopCoroutine(_flamethrowingCoroutine);

        DisableGraphics();
    }

    private void OnDestroy() {
        _loadedSoundboard.Dispose();
        _soundboardReference.ReleaseAssetSafe();
    }
}
