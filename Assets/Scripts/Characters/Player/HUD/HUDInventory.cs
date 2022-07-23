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
                HUDInventorySlot hudSlot = slot.GetComponent<HUDInventorySlot>();
                _inventory.Add(hudSlot);
            };
        }

        await Task.WhenAll(inventoryInit);
        SetupInventoryIndecies(slotCount);
        HighlightSlot(0);
    }

    private void SetupInventoryIndecies(int slotCount)
    {
        for(int i = 0; i < slotCount; i++)
        {
            _inventory[i].indexText.text = (i + 1).ToString();
        }
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

    private void OnDestroy()
    {
        foreach(HUDInventorySlot slot in _inventory)
        {
            Addressables.ReleaseInstance(slot.gameObject);
        }
        _inventory.Clear();
    }
}
