using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    [System.Serializable]
    public enum ItemType
    {
        Flare,
        Medkit,
        Flashlight,
        Paint,
        Treasure
    }



    private int _id;
    public int ID
    {
        get
        {
            return _id;
        }
    }
    private ItemType _type;
    public ItemType Type
    {
        get
        {
            return _type;
        }
    }
    //private GameObject _dropPrefab;
    //public GameObject DropPrefab
    //{
    //    get
    //    {
    //        return _dropPrefab;
    //    }
    //}

    private Sprite _inventoryIcon;
    public Sprite InventoryIcon
    {
        get
        {
            return _inventoryIcon;
        }
    }

    private bool _isConsumable;
    public bool IsConsumable
    {
        get
        {
            return _isConsumable;
        }
    }
    private bool _isStackable;
    public bool IsStackable
    {
        get
        {
            return _isStackable;
        }
    }
    private bool _useOnRelease;
    public bool UseOnRelease
    {
        get
        {
            return _useOnRelease;
        }
    }

    public Item(ItemSO so /*GameObject prefab*/)
    {
        _type = so.type;
        _id = so.itemID;
        //_dropPrefab = prefab;

        _inventoryIcon = so.inventoryIcon;

        _isStackable = so.isStackable;
        _isConsumable = so.isConsumable;
        _useOnRelease = so.useOnRelease;
    }

    public abstract void OnDrop(PlayerController user);
    public abstract void Use(PlayerController user);
    public abstract bool OnButtonPressed(PlayerController user);
    public abstract bool OnButtonReleased(PlayerController user);
}
