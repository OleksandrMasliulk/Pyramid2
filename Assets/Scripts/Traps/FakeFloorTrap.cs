using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeFloorTrap : TrapMaster
{
    public override void Trigger(Player target)
    {
        Debug.Log("FAKE FLOOR TRAP ACTIVATED");
        ReduceSanity(target);

        base.Trigger(target);
    }

    protected override void Activate(Player target)
    {
        base.Activate(target);

        target.TakeDamage(1);
        isActive = false;
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
