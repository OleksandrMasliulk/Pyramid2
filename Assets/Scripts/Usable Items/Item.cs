 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public abstract class Item
{
    public enum ItemType
    {
        Flashlight,
        Medkit,
        Flare,
        Paint,
        Treasure
    }

    private ItemType _type;
    public ItemType Type => _type;
    private int _id;
    public int ID => _id;
    private string _name;
    public string Name => _name;
    private Sprite _icon;
    public Sprite Icon => _icon;
    private GameObject _itemDropPrefab;
    public GameObject ItemDropPrefab => _itemDropPrefab;

    private bool _isStackable;
    public bool IsStackable => _isStackable;
    private int _maxStack;
    public int MaxStack => _maxStack;
    private bool _isConsumable;
    public bool IsConsumable => _isConsumable;

    public Item(ItemSO so)
    {
        this._type = so.type;
        this._id = so.itemID;
        //this._name = so
        this._icon = so.inventoryIcon;
        this._itemDropPrefab = so.dropPrefab;
        this._isStackable = so.isStackable;
        this._maxStack = so.maxStack;
        this._isConsumable = so.isConsumable;
    }
}
