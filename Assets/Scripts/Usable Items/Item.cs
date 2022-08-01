using UnityEngine;

public abstract class Item {
    public enum ItemType {
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
        _type = so.type;
        _id = so.itemID;
        //_name = so
        _icon = so.inventoryIcon;
        _itemDropPrefab = so.dropPrefab;
        _isStackable = so.isStackable;
        _maxStack = so.maxStack;
        _isConsumable = so.isConsumable;
    }
}
