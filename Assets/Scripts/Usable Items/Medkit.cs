using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Medkit : Item
{
    private int sanityRestoreValue;

    public Medkit(MedkitSO so/*, GameObject prefab*/) : base(so/*, prefab*/)
    {
        sanityRestoreValue = so.restoreAmount;
    }

    public override void Use(PlayerController user)
    {
        Debug.Log("MEDKIT USED");

        Heal(user);
    }

    private void Heal(PlayerController user)
    {
        user.SanityController.UpdateSanity(sanityRestoreValue);
    }

    public override bool OnButtonPressed(PlayerController user)
    {
        Use(user);

        return !UseOnRelease;
    }

    public override bool OnButtonReleased(PlayerController user)
    {
        return UseOnRelease;
    }

    public override void OnDrop(PlayerController user)
    {
    }
}
