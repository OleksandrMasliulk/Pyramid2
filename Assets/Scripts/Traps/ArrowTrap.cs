using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : Trap, IInterractible
{
    public ParticleSystem arrows;

    [SerializeField] private float rearmTime;
    private bool canShoot;
    private float timeToRearm;

    public string tooltip { get; set; }

    private void Start()
    {
        canShoot = true;
        timeToRearm = 0;
    }

    private void Shoot()
    {
        arrows.Play();
        AudioManager.Instance.PlayerSound3D(AudioManager.Instance.GetSoundBoard<TrapsSoundBoard>().arrowTrapShoot, transform.position, .3f);

        canShoot = false;
        timeToRearm = rearmTime;
    }

    private void Update()
    {
        if (!canShoot)
        {
            if (timeToRearm <= 0)
            {
                canShoot = true;
            }
            else
            {
                timeToRearm -= Time.deltaTime;
            }
        }
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

    public override void Activate(IDamageable target)
    {
        Shoot();
    }

    public void Interract(PlayerController user)
    {
        if (canShoot)
        {
            if (user != null)
            {
                ReduceSanity(user);
            }

            Activate(null);
        }
    }
}
