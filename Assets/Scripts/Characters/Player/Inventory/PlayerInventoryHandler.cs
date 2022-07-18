using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class PlayerInventoryHandler : MonoBehaviour
{
    private PlayerDrivenCharacter _character;
    private CharacterInventory _inventory;
    private PlayerInputHandler _inputHandler;

    private int _selectedSlot;

    private void Awake()
    {
        _character = GetComponent<PlayerDrivenCharacter>();
    }

    public void Init(PlayerInputHandler inputHandler, int slotCount)
    {
        _inventory = new CharacterInventory(slotCount);
        _selectedSlot = 0;

        this._inputHandler = inputHandler;

        _inputHandler.OnSlot1 += SelectSlot0;
        _inputHandler.OnSlot2 += SelectSlot1;
        _inputHandler.OnSlot3 += SelectSlot2;
        _inputHandler.OnSlot4 += SelectSlot3;

        _inputHandler.OnUsePress += UseItemPress;
        _inputHandler.OnUseRelease += UseItemRelease;
        _inputHandler.OnDrop += DropItem;
    }

    public AddItemCallback AddItem(Item item, int count)
    {
        AddItemCallback callback = _inventory.AddItem(item, count);

        Debug.Log(callback.Result.ToString());

        if (callback.Result == AddItemCallback.ResultType.Failed)
            Debug.LogWarning("Inventory is FULL");

        if (callback.Result != AddItemCallback.ResultType.Failed)
            _character.HUDHandler.Inventory.RefreshInventoryHUD(_inventory);

        return callback;
    }

    public void DropItem()
    {
        if (_inventory.Inventory[_selectedSlot].Item == null)
            return;

        GameObject go = Instantiate(_inventory.Inventory[_selectedSlot].Item.ItemDropPrefab, transform.position, Quaternion.identity);
        go.GetComponent<Pickable>().SetCount(_inventory.Inventory[_selectedSlot].Count);
        _inventory.RemoveItem(_selectedSlot);
        _character.HUDHandler.Inventory.RefreshInventoryHUD(_inventory);
    }

    private void UseItemPress()
    {
        if (_inventory.Inventory[_selectedSlot].Item == null)
            return;

        if(_inventory.Inventory[_selectedSlot].Item is IUseOnPress pressUse)
        {
            if (pressUse.UseOnPress(_character).Result == UseItemCallback.ResultType.Failed)
                return;

            if (_inventory.Inventory[_selectedSlot].Item.IsConsumable)
                _inventory.ConsumeItem(_selectedSlot);
            _character.HUDHandler.Inventory.RefreshInventoryHUD(_inventory);
        }
    }
    
    private void UseItemRelease()
    {
        if (_inventory.Inventory[_selectedSlot].Item == null)
            return;

        if (_inventory.Inventory[_selectedSlot].Item is IUseOnRelease releaseUse)
        {
            if (releaseUse.UseOnRelease(_character).Result == UseItemCallback.ResultType.Failed)
                return;

            if (_inventory.Inventory[_selectedSlot].Item.IsConsumable)
                _inventory.ConsumeItem(_selectedSlot);
            _character.HUDHandler.Inventory.RefreshInventoryHUD(_inventory);
        }
    }

    private void SelectSlot0()
    {
        _selectedSlot = 0;
        _character.HUDHandler.Inventory.HighlightSlot(_selectedSlot);
    }
    private void SelectSlot1()
    {
        _selectedSlot = 1;
        _character.HUDHandler.Inventory.HighlightSlot(_selectedSlot);
    }
    private void SelectSlot2()
    {
        _selectedSlot = 2;
        _character.HUDHandler.Inventory.HighlightSlot(_selectedSlot);
    }
    private void SelectSlot3()
    {
        _selectedSlot = 3;
        _character.HUDHandler.Inventory.HighlightSlot(_selectedSlot);
    }
}
