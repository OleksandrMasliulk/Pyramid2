using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : TrapMaster
{
    public ParticleSystem ps;

    protected override void Activate(Player target)
    {
        Debug.Log("ARROW TRAP ACTIVATED");

        base.Activate(target);

        Shoot();
    }

    protected override void AffectSanity(Player target)
    {
        base.AffectSanity(target);

        target.UpdateSanity(-sanityLoss);
    }

    private void Shoot()
    {
        ps.Play();
    }
}
