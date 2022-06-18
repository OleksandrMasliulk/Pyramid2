using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    public enum ItemType
    {
        Flare,
        Medkit,
        Flashlight,
        Paint,
        Treasure
    }

    public ItemType type;

    public Sprite inventoryImage;
    [HideInInspector]public GameObject dropObject;

    public bool isStackable;
    public bool isConsumable;
    public bool useOnRelease;

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
