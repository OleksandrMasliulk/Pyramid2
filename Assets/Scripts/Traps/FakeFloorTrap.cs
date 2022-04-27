using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeFloorTrap : TrapMaster
{
    public override void Trigger(PlayerController target)
    {
        Debug.Log("FAKE FLOOR TRAP ACTIVATED");
        ReduceSanity(target);

        base.Trigger(target);
    }

    protected override void Activate(PlayerController target)
    {
        base.Activate(target);

        target.GetComponent<IDamageable>().TakeDamage(1);
        isActive = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null)
        {
            Trigger(player);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null)
        {
            StopCountdown();
        }
    }
}
