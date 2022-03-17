using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMaster : MonoBehaviour
{
    public int sanityLoss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            Trigger(player);
        }
    }

    protected virtual void Trigger(Player target)
    {
        target.UpdateSanity(-sanityLoss);
    }
}
