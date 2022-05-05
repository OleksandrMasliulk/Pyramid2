using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Lever : Interractible
{
    public Interractible objToActivate;

    public override void Action(PlayerController user)
    {
        objToActivate.Action(user);
    }
}
