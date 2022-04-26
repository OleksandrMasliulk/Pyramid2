using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : Item
{
    protected override void Init()
    {
        Debug.Log("MEDICINE CLASEE CONSTRUCTED");
        base.Init();

        isStackable = true;
        isConsumable = true;

        //PATHS
        pickableMirrorPath = "Pickable Items/Pickable Medicine";
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
}
