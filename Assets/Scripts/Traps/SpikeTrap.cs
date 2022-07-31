using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : Trap, ISwitchable
{
    [SerializeField] private float _spikeDuration;
    [SerializeField] private float _triggerDelay;
    //private bool _isPopped = false;

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
        if (_spikesCoroutine != null)
            return;

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

    IEnumerator PopSpikes()
    {
        yield return new WaitForSeconds(_triggerDelay);
        _anim.SetBool("isActive", true);
        //_isPopped = true;

        float startTime = Time.time;
        while (startTime + _spikeDuration > Time.time && IsActive)
        {
            foreach (IDamageable d in _damageSeeker.ObjectsSeeked)
            {
                d.TakeDamage(1);
            }
            yield return new WaitForSeconds(DefaultTickTime);
            Debug.Log("Spike Trap tick");
        }
        Debug.Log("Spike Trap done");
        HideSpikes();
    }

    private void HideSpikes()
    {
        _spikesCoroutine = null;
        _anim.SetBool("isActive", false);
        //_isPopped = false;
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
        _isActive = false;
        if (_spikesCoroutine != null)
        {
            StopCoroutine(_spikesCoroutine);
            HideSpikes();
        }
    }

    public void Activate()
    {
        _isActive = true;
    }
}
