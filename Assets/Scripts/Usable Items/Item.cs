using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string pickableMirrorPath;
    public string inventoryImagePath;

    public bool isStackable;
    public bool isConsumable;

    public Item()
    {
        Init();
    }

    protected virtual void Init()
    {
        pickableMirrorPath = null;
        inventoryImagePath = null;
    }

    public virtual void Use(PlayerInventoryController user)
    {
    }
}
