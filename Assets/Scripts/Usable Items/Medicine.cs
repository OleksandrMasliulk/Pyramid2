using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : Item
{
    public Medicine()
    {
        Debug.Log("MEDICINE CLASEE CONSTRUCTED");

        this.type = ItemType.Medkit;
        ItemAssets.Instance.GetItem(type, out pickableMirror, out inventoryImage);

        useOnRelease = false;
        isConsumable = true;
        isStackable = true;
    }

    public override void Use(PlayerController user)
    {
        Debug.Log("MEDKIT USED");
        base.Use(user);

        Heal(user);
    }

    private void Heal(PlayerController user)
    {
        user.GetPlayerSanityController().UpdateSanity(30);
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
