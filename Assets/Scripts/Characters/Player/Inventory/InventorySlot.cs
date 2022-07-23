using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot
{
    public Item Item { get; set; }
    public int Count { get; set; }

    public InventorySlot()
    {
        Item = null;
        Count = 0;
    }
}
