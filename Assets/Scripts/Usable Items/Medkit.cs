using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Medkit : Item
{
    public int sanityRestoreValue;

    public override void Use(PlayerController user)
    {
        Debug.Log("MEDKIT USED");
        base.Use(user);

        Heal(user);
    }

    private void Heal(PlayerController user)
    {
        user.GetPlayerSanityController().UpdateSanity(sanityRestoreValue);
    }

    public override bool OnButtonPressed(PlayerController user)
    {
        Use(user);

        return base.OnButtonPressed(user);
    }

    public override bool OnButtonReleased(PlayerController user)
    {
        return base.OnButtonReleased(user);
    }
}
