using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : Interractible
{
    public int value;

    protected override void Action(PlayerInterractionController user)
    {
        Gather();
    }

    private void Gather()
    {
        Debug.Log("+" + value);
        isActive = false;
    }
}
