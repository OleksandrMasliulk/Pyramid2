using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerTrap : Trap, ISwitchable
{
    [SerializeField] private GameObject _fireGraphics;
    [SerializeField] private ParticleSystem _ps;
    [SerializeField] private ParticleSystem _ps2;

    [SerializeField] private ISeeker<IHaveSanity> _sanitySeeker;
    [SerializeField] private ISeeker<IDamageable> _damageSeeker;

    [SerializeField] private float _rearmTime;
    [SerializeField] private float _flameThrowingDuration;
    private bool _isReady;

    [SerializeField] private bool _isActive;
    public bool IsActive => _isActive;

    private Coroutine _rearmCoroutine;
    private Coroutine _flamethrowingCoroutine;

    private void Awake()
    {
        _sanitySeeker = GetComponentInChildren<ISeeker<IHaveSanity>>();
        _damageSeeker = GetComponentInChildren<ISeeker<IDamageable>>();
    }

    private void Start()
    {
        _flamethrowingCoroutine = StartCoroutine(ThrowFireCoroutine());
    }

    IEnumerator ThrowFireCoroutine()
    {
        AudioManager.Instance.PlayerSound3D(AudioManager.Instance.GetSoundBoard<TrapsSoundBoard>().flamethrowerTrap, transform.position, _flameThrowingDuration);

        foreach (IHaveSanity s in _sanitySeeker.ObjectsSeeked)
        {
            s.ModifySanity(-sanityLoss);
        }

        EnableGraphics();
        float startThrowingTime = Time.time;
        while (startThrowingTime + _flameThrowingDuration >= Time.time && IsActive)
        {
            foreach(IDamageable d in _damageSeeker.ObjectsSeeked)
            {
                d.TakeDamage(1);
                Debug.Log("Flamethrower trap hit");
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }

        if (IsActive)
            _rearmCoroutine = StartCoroutine(RearmCoroutine());
    }

    IEnumerator RearmCoroutine()
    {
        DisableGraphics();

        _isReady = false;
        yield return new WaitForSeconds(_rearmTime);
        _isReady = true;

        if (IsActive)
            _flamethrowingCoroutine = StartCoroutine(ThrowFireCoroutine());
    }

    private void EnableGraphics()
    {
        _fireGraphics.SetActive(true);
        _ps.Play();
        _ps2.Play(); 
    }

    private void DisableGraphics()
    {
        _fireGraphics.SetActive(false);
        _ps.Stop();
        _ps2.Stop();
    }

    public override void Trigger()
    {
    }

    public void Activate()
    {
        _isActive = true;

        if (_isReady)
        {
            if (_rearmCoroutine != null)
                StopCoroutine(_rearmCoroutine);
            _flamethrowingCoroutine = StartCoroutine(ThrowFireCoroutine());
        }
        else
        {
            if (_rearmCoroutine == null)
                _rearmCoroutine = StartCoroutine(RearmCoroutine());
        }
            
    }

    public void Disable()
    {
        _isActive = false;

        if (_flamethrowingCoroutine != null)
            StopCoroutine(_flamethrowingCoroutine);

        DisableGraphics();
    }
}
