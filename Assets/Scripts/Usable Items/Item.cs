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
    public int ID => _id;
    private ItemType _type;
    public ItemType Type => _type;

    private Sprite _inventoryIcon;
    public Sprite InventoryIcon => _inventoryIcon;

    private bool _isConsumable;
    public bool IsConsumable => _isConsumable;
    private bool _isStackable;
    public bool IsStackable => _isStackable;
    private int _maxStack;
    public int MaxStack => _maxStack;
    private bool _useOnRelease;
    public bool UseOnRelease => _useOnRelease;

    public Item(ItemSO so /*GameObject prefab*/)
    {
        _type = so.type;
        _id = so.itemID;
        //_dropPrefab = prefab;

        _inventoryIcon = so.inventoryIcon;

        _isStackable = so.isStackable;
        _maxStack = so.maxStack;
        _isConsumable = so.isConsumable;
        _useOnRelease = so.useOnRelease;
    }

    public virtual void OnPickUp(PlayerController player)
    {
        AudioManager.Instance.PlaySound(AudioManager.Instance.GetSoundBoard<ItemsSoundboard>().pickUp, 1f);
    }
    public abstract void OnDrop(PlayerController user);
    public abstract void Use(PlayerController user);
    public abstract bool OnButtonPressed(PlayerController user);
    public abstract bool OnButtonReleased(PlayerController user);
}
