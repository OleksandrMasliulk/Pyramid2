using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : Trap, ISwitchable
{
    public ParticleSystem arrows;

    [SerializeField] private float _rearmTime;
    private float _lastTimeShooted;

    public string Tooltip { get; set; }

    [SerializeField] private bool _isActive;
    public bool IsActive => _isActive;

    private void Awake()
    {
        _lastTimeShooted = Time.time;
    }

    private void Shoot()
    {
        if (Time.time + _rearmTime < _lastTimeShooted)
            return;

        arrows.Play();
        AudioManager.Instance.PlayerSound3D(AudioManager.Instance.GetSoundBoard<TrapsSoundBoard>().arrowTrapShoot, transform.position, .3f);

        _lastTimeShooted = Time.time;
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Arrow hit");

        IDamageable target = other.GetComponent<IDamageable>();

        if (target != null)
        {
            target.TakeDamage(1);
        }
    }

    public override void Trigger()
    {
        if (!IsActive)
            return;

        Shoot();
    }

    public void Activate()
    {
        _isActive = true;
    }

    public void Disable()
    {
        _isActive = false;
    }
}
