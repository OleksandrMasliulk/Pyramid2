public class CharacterInventory
{
    private int _slotCount;
    public int SlotCount => _slotCount;
    private InventorySlot[] _inventory;
    public InventorySlot[] Inventory => _inventory;

    public CharacterInventory(int slotCount) {
        _slotCount = slotCount;
        _inventory = new InventorySlot[_slotCount];
        for (int i = 0; i < _slotCount; i++)
            _inventory[i] = new InventorySlot();
    }

    public AddItemCallback AddItem(Item item, int count) {
        int c = count;
        if (!item.IsStackable) {
            int pointer = 0;
            while (pointer < _slotCount && c > 0) {
                if (_inventory[pointer].Item == null) {
                    _inventory[pointer].Item = item;
                    _inventory[pointer].Count = 1;
                    c--;
                }
                pointer++;
            }
            if (c == 0)
                return new AddItemCallback(AddItemCallback.ResultType.Success);
            else if (c < count)
                return new AddItemCallback(AddItemCallback.ResultType.Partially, c);
            else
                return new AddItemCallback(AddItemCallback.ResultType.Failed);
        }
        else {
            int pointer = 0;
            while (pointer < _slotCount && c > 0) {
                if (_inventory[pointer].Item == null) {
                    _inventory[pointer].Item = item;
                    while (_inventory[pointer].Count < item.MaxStack && c > 0) {
                        _inventory[pointer].Count++;
                        c--;
                    }
                }
                else if (_inventory[pointer].Item.ID == item.ID && _inventory[pointer].Count < item.MaxStack) {
                    while (_inventory[pointer].Count < item.MaxStack && c > 0) {
                        _inventory[pointer].Count++;
                        c--;
                    }
                }
                pointer++;
            }
            if (c == 0)
                return new AddItemCallback(AddItemCallback.ResultType.Success);
            else if (c < count)
                return new AddItemCallback(AddItemCallback.ResultType.Partially, c);
            else
                return new AddItemCallback(AddItemCallback.ResultType.Failed);
        }
    }

    public void RemoveItem(InventorySlot slot) {
        slot.Item = null;
        slot.Count = 0;
    }
    
    public void RemoveItem(int slot) {
        _inventory[slot].Item = null;
        _inventory[slot].Count = 0;
    }

    public void ConsumeItem(int slot) {
        _inventory[slot].Count--;
        if (_inventory[slot].Count <= 0)
            RemoveItem(slot);
    }
}
