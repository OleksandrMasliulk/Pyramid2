using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : TrapMaster
{
    public float triggerDelay;

    protected override void Trigger(Player target)
    {
        base.Trigger(target);

        Debug.LogWarning("SPIKE TRAP TRIGGERED");
        //StartCoroutine(DoDamageCoroutine(target));
    }

    IEnumerator DoDamageCoroutine(Player target)
    {
        yield return new WaitForSeconds(triggerDelay);

        DoDamage(target);
    }

    private void DoDamage(Player target)
    {
        target.TakeDamage(1);
    }
}
