using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : TrapMaster
{
    protected override void Trigger(Player target)
    {
        base.Trigger(target);

        Debug.LogWarning("ARROW TRAP TRIGGERED");
        //DoDamage(target);
    }

    private void DoDamage(Player target)
    {
        target.TakeDamage(1);
    }
}
