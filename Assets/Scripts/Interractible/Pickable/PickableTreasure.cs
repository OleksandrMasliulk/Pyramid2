using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableTreasure : Item
{
    public int value = 10;

    protected override void Init()
    {
        Debug.Log("TREASURE CLASEE CONSTRUCTED");
        base.Init();

        isStackable = false;
        isConsumable = true;
        useOnRelease = false;

        //PATHS
        pickableMirrorPath = "Pickable Items/Pickable Treasure";
    }

    public override void Use(PlayerController user)
    {
    }
}
