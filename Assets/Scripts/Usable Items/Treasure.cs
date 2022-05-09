using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : Item
{
    public int value;

    public Treasure(ItemType type)
    {
        Debug.Log("TREASURE CLASEE CONSTRUCTED");

        switch (type)
        {
            case ItemType.Treasure5:
                value = 5;
                break;
            case ItemType.Treasure10:
                value = 10;
                break;
            default:
                type = ItemType.Treasure5;
                value = 5;
                break;
        }

        this.type = type;
        ItemAssets.Instance.GetItem(type, out pickableMirror, out inventoryImage);

        useOnRelease = false;
        isConsumable = false;
        isStackable = false;
    }
}
