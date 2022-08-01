using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System;
using UnityEngine.InputSystem;

public class PlayerInventoryHandler : MonoBehaviour
{
    private PlayerDrivenCharacter _character;
    private CharacterInventory _inventory;

    private int _selectedSlot;

    public event Action<CharacterInventory> OnInventoryChanged;
    public event Action<int> OnSlotSelected;

    private void Awake()
    {
        _character = GetComponent<PlayerDrivenCharacter>();
    }

    public void Init(int slotCount)
    {
        _inventory = new CharacterInventory(slotCount);
        _selectedSlot = 0;
    }

    public AddItemCallback AddItem(Item item, int count)
    {
        AddItemCallback callback = _inventory.AddItem(item, count);

        Debug.Log(callback.Result.ToString());

        if (callback.Result == AddItemCallback.ResultType.Failed)
            Debug.LogWarning("Inventory is FULL");

        if (callback.Result != AddItemCallback.ResultType.Failed)
        {
            if (item is IItemPickUp pickUp)
                pickUp.OnPickUp(_character);
            OnInventoryChanged?.Invoke(_inventory);
        }

        return callback;
    }

    public void DropItem(InputAction.CallbackContext context)
    {
        if (_inventory.Inventory[_selectedSlot].Item == null)
            return;

        if (_inventory.Inventory[_selectedSlot].Item is IItemDrop drop)
            drop.OnDrop(_character);

        GameObject go = Instantiate(_inventory.Inventory[_selectedSlot].Item.ItemDropPrefab, transform.position, Quaternion.identity);
        go.GetComponent<Pickable>().Init(_inventory.Inventory[_selectedSlot].Item, _inventory.Inventory[_selectedSlot].Count); //SetCount(_inventory.Inventory[_selectedSlot].Count);
        _inventory.RemoveItem(_selectedSlot);
        OnInventoryChanged?.Invoke(_inventory);
    }

    private void UseItemPress(InputAction.CallbackContext context)
    {
        if (_inventory.Inventory[_selectedSlot].Item == null)
            return;

        if(_inventory.Inventory[_selectedSlot].Item is IUseOnPress pressUse)
        {
            if (pressUse.UseOnPress(_character).Result == UseItemCallback.ResultType.Failed)
                return;

            if (_inventory.Inventory[_selectedSlot].Item.IsConsumable)
                _inventory.ConsumeItem(_selectedSlot);
            OnInventoryChanged?.Invoke(_inventory);
        }
    }
    
    private void UseItemRelease(InputAction.CallbackContext context)
    {
        if (_inventory.Inventory[_selectedSlot].Item == null)
            return;

        if (_inventory.Inventory[_selectedSlot].Item is IUseOnRelease releaseUse)
        {
            if (releaseUse.UseOnRelease(_character).Result == UseItemCallback.ResultType.Failed)
                return;

            if (_inventory.Inventory[_selectedSlot].Item.IsConsumable)
                _inventory.ConsumeItem(_selectedSlot);
            OnInventoryChanged?.Invoke(_inventory);
        }
    }

    private void SelectSlot1(InputAction.CallbackContext context)
    {
        _selectedSlot = 0;
        OnSlotSelected?.Invoke(_selectedSlot);
    }
    private void SelectSlot2(InputAction.CallbackContext context)
    {
        _selectedSlot = 1;
        OnSlotSelected?.Invoke(_selectedSlot);
    }
    private void SelectSlot3(InputAction.CallbackContext context)
    {
        _selectedSlot = 2;
        OnSlotSelected?.Invoke(_selectedSlot);
    }
    private void SelectSlot4(InputAction.CallbackContext context)
    {
        _selectedSlot = 3;
        OnSlotSelected?.Invoke(_selectedSlot);
    }


    private void OnEnable()
    {
        _character.InputController.CharacterActions.SelectSlot1.performed += SelectSlot1;
        _character.InputController.CharacterActions.SelectSlot2.performed += SelectSlot2;
        _character.InputController.CharacterActions.SelectSlot3.performed += SelectSlot3;
        _character.InputController.CharacterActions.SelectSlot4.performed += SelectSlot4;

        _character.InputController.CharacterActions.Useitem.performed += UseItemPress;
        _character.InputController.CharacterActions.Useitem.canceled += UseItemRelease;
        _character.InputController.CharacterActions.DropItem.performed += DropItem;
    }

    private void OnDisable()
    {
        _character.InputController.CharacterActions.SelectSlot1.performed -= SelectSlot1;
        _character.InputController.CharacterActions.SelectSlot2.performed -= SelectSlot2;
        _character.InputController.CharacterActions.SelectSlot3.performed -= SelectSlot3;
        _character.InputController.CharacterActions.SelectSlot4.performed -= SelectSlot4;

        _character.InputController.CharacterActions.Useitem.performed -= UseItemPress;
        _character.InputController.CharacterActions.Useitem.canceled -= UseItemRelease;
        _character.InputController.CharacterActions.DropItem.performed -= DropItem;
    }
}
