using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : Trap, ISwitchable
{
    [SerializeField] private float _spikeDuration;
    [SerializeField] private float _triggerDelay;
    private bool _isPopped = false;

    [SerializeField] private Animator _anim;

    private ISeeker<IHaveSanity> _sanitySeeker;
    private ISeeker<IDamageable> _damageSeeker;

    private Coroutine _spikesCoroutine;

    [SerializeField] private bool _isActive;
    public bool IsActive => _isActive;

    private void Awake()
    {
        _sanitySeeker = GetComponent<ISeeker<IHaveSanity>>();
        _damageSeeker = GetComponent<ISeeker<IDamageable>>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CharacterBase>())
            Trigger();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_spikesCoroutine == null)
            return;

        if (collision.GetComponent<CharacterBase>())
        {
            StopCoroutine(_spikesCoroutine);
            _spikesCoroutine = null;
        }
    }

    private void Update()
    {
        if (_isPopped )
        {
            foreach (IDamageable d in _damageSeeker.ObjectsSeeked)
            {
                d.TakeDamage(1);
            }
        }
    }

    IEnumerator PopSpikes()
    {
        yield return new WaitForSeconds(_triggerDelay);
        _anim.SetBool("isActive", true);
        _isPopped = true;
        foreach (IDamageable d in _damageSeeker.ObjectsSeeked)
        {
            d.TakeDamage(1);
        }
        StartCoroutine(HideSpikes());
    }

    private IEnumerator HideSpikes()
    {
        yield return new WaitForSeconds(_spikeDuration);
        _anim.SetBool("isActive", false);
        _isPopped = false;
    }

    public override void Trigger()
    {
        if (!IsActive)
            return;

        if (_spikesCoroutine != null)
            return;

        _spikesCoroutine = StartCoroutine(PopSpikes());
        foreach (IHaveSanity s in _sanitySeeker.ObjectsSeeked)
        {
            s.ModifySanity(-sanityLoss);
        }
    }

    public void Disable()
    {
        if (_spikesCoroutine != null)
            StopCoroutine(_spikesCoroutine);

        _isActive = false;
    }

    public void Activate()
    {
        _isActive = true;

        if (_isPopped)
            StartCoroutine(HideSpikes());
    }
}
