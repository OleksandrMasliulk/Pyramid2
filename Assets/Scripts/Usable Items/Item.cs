using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Flare,
        Medkit,
        Flashlight,
        Paint,
        Treasure5,
        Treasure10
    }

    public Transform pickableMirror;
    public Sprite inventoryImage;

    public bool isStackable;
    public bool isConsumable;
    public bool useOnRelease;

    public ItemType type;

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
