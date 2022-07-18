using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;

public class HUDInventory : MonoBehaviour
{
    [SerializeField] private AssetReference _slotPrefab;
    [SerializeField] private RectTransform _slotParent;
    private List<HUDInventorySlot> _inventory;

    private int _higlightedSlot;

    public async void Init(int slotCount)
    {
        _inventory = new List<HUDInventorySlot>();
        List<Task> inventoryInit = new List<Task>();
        for (int i = 0; i < slotCount; i++)
        {
            var op = _slotPrefab.InstantiateAsync(_slotParent);
            inventoryInit.Add(op.Task);
            op.Completed += (op) =>
            {
                GameObject slot = op.Result;
                _inventory.Add(slot.GetComponent<HUDInventorySlot>());
            };
        }

        await Task.WhenAll(inventoryInit);

        HighlightSlot(0);
    }

    public void RefreshInventoryHUD(CharacterInventory inv)
    {
        for(int i = 0; i < inv.SlotCount; i++)
        {
            _inventory[i].SetupSlot(inv.Inventory[i]);
        }
    }

    public void HighlightSlot(int slot)
    {
        _inventory[_higlightedSlot].gameObject.GetComponent<IHighlight>().UnHighlight();
        _inventory[slot].gameObject.GetComponent<IHighlight>().Highlight();
        _higlightedSlot = slot;
    }

    private void OnDisable()
    {
        foreach(HUDInventorySlot slot in _inventory)
        {
            Addressables.ReleaseInstance(slot.gameObject);
        }
        _inventory.Clear();
    }
}
