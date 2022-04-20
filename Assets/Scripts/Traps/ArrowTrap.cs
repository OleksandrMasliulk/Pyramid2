using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : TrapMaster
{
    public ParticleSystem arrows;

    protected override void Activate(Player target)
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

        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            player.TakeDamage(1);
        }
    }
}
