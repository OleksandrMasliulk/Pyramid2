using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover : Interractible
{
    [SerializeField] private Transform respawnPos;

    public override void Action(PlayerController user)
    {
        base.Action(user);

        if (user.GetPlayerParameters().isCovered)
        {
            user.GetPlayerCoverController().Uncover(respawnPos.position);
        }
        else
        {
            user.GetPlayerCoverController().Cover(transform.position);
        }
    }
}
