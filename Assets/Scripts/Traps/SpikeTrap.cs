using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : TrapMaster
{
    public override void Trigger(Player target)
    {
        Debug.Log("SPIKE TRAP ACTIVATED");
        AffectSanity(target);

        base.Trigger(target);
    }

    protected override void AffectSanity(Player target)
    {
        base.AffectSanity(target);

        target.UpdateSanity(-sanityLoss);
    }

    protected override void Activate(Player target)
    {
        base.Activate(target);

        target.TakeDamage(1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            Trigger(player);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            StopCountdown();
        }
    }
}
