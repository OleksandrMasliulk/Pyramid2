using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string pickableMirrorPath;
    public string inventoryImagePath;

    public bool isStackable;
    public bool isConsumable;
    public bool useOnRelease;

    public Item()
    {
        Init();
    }

    protected virtual void Init()
    {
        pickableMirrorPath = null;
        inventoryImagePath = null;
        useOnRelease = false;
    }

    public virtual void OnDrop(PlayerController user)
    { 
    }

    public virtual void Use(PlayerController user)
    {
    }

    public virtual bool OnButtonPressed(PlayerController user)
    {
        return !useOnRelease;
    }

    public virtual bool OnButtonReleased(PlayerController user)
    {
        return useOnRelease;
    }

    public bool GetUseOnRelease()
    {
        return useOnRelease;
    }
}
