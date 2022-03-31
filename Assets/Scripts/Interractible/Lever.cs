using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interractible
{
    private bool position;

    protected override void Action(PlayerInterractionController user)
    {
        if (!position)
        {
            SwitchActive();
        }
        else
        {
            SwitchUnactive();
        }

        Debug.Log("Lever position: " + position);
    }

    private void SwitchActive()
    {
        position = true;
    }

    private void SwitchUnactive()
    {
        position = false;
    }
}
