using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : TrapMaster
{
    public ParticleSystem arrows;

    protected override void Activate(PlayerController target)
    {
        Debug.Log("ARROW TRAP ACTIVATED");

        base.Activate(target);

        Shoot();
        ReduceSanity(target);
    }

    private void Shoot()
    {
        arrows.Play();
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
}
