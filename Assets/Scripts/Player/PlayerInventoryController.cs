using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    private PlayerHUDController hud;

    private InventorySlot[] inventory;
    private const int inventorySlots = 4;

    private int slotToUse;

    private void Start()
    {
        hud = GetComponent<PlayerHUDController>();

        inventory = new InventorySlot[inventorySlots];
        slotToUse = 0;
        SwitchSlot(slotToUse);

        for (int i = 0; i < inventorySlots; i++)
        {
            hud.UpdateInventorySlot(i, inventory[i]);
        }
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            ScrollLeft();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ScrollRight();
        }*/
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchSlot(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchSlot(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchSlot(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SwitchSlot(3);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            UseItem();
        }
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            Drop();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            foreach (InventorySlot slot in inventory)
            {
                Debug.Log(slot.item + ": " + slot.count);
            }
        }
    }

    public bool AddToInventory(Item item, int count)
    {
        if (item.isStackable)
        {
            for (int i = 0; i < inventorySlots; i++)
            {
                if (inventory[i].item != null && inventory[i].item.GetType() == item.GetType())
                {
                    inventory[i] = new InventorySlot(item, inventory[i].count + count);
                    Debug.Log("Stacked");

                    hud.UpdateInventorySlot(i, inventory[i]);

                    return true;
                }
            }
        }

        if (CheckIfIsFull())
        {
            Debug.Log("Inventory is FULL");

            return false;
        }
        else
        {
            for (int i = 0; i < inventorySlots; i++)
            {
                if (inventory[i].item == null)
                {
                    inventory[i] = new InventorySlot(item, count);
                    Debug.Log("Item added");

                    hud.UpdateInventorySlot(i, inventory[i]);

                    return true;
                }
            }
        }

        return false;
        /*if (CheckIfIsFull())
        {
            Debug.Log("Inventory is FULL");

            return;
        }

        for (int i = 0; i < inventorySlots; i++)
        {
            //Stack items
            if (item == inventory[i].item)
            {
                if (item.isStackable)
                {
                    inventory[i] = new InventorySlot(item, inventory[i].count + count);
                    Debug.Log("Stacked");

                    return;
                }
                else
                {
                    continue;
                }
            }

            //Add new item
            if (inventory[i].item == null)
            {
                inventory[i] = new InventorySlot(item, count);
                Debug.Log("Item added");

                return;
            }
        }*/
    }

    private bool CheckIfIsFull()
    {
        foreach(InventorySlot slot in inventory)
        {
            if (slot.item == null)
            {
                return false;
            } 
        }

        return true;
    }

    private void UseItem()
    {
        if (inventory[slotToUse].item == null)
        {
            Debug.Log("Slot is empty");

            return;
        }

        inventory[slotToUse].item.Use(this);

        if (inventory[slotToUse].item.isConsumable)
        {
            int newCount = inventory[slotToUse].count - 1;

            if (newCount == 0)
            {
                inventory[slotToUse] = new InventorySlot(null, 0);
            }
            else
            {
                inventory[slotToUse] = new InventorySlot(inventory[slotToUse].item, inventory[slotToUse].count - 1);
            }

            hud.UpdateInventorySlot(slotToUse, inventory[slotToUse]);
        }
    }

    private void SwitchSlot(int num)
    {
        slotToUse = num;
        Debug.Log("Slot to use: " + num);

        if (hud != null)
        {
            hud.HighlightInventorySlot(num);
        }
    }

    private void Drop()
    {
        if (inventory[slotToUse].item == null)
        {
            Debug.Log("Slot is empty");

            return;
        }
        else
        {
            var obj = Resources.Load(inventory[slotToUse].item.pickableMirrorPath);

            Instantiate((GameObject)obj, transform.position, Quaternion.identity);

            int newCount = inventory[slotToUse].count - 1;

            if (newCount == 0)
            {
                inventory[slotToUse] = new InventorySlot(null, 0);
            }
            else
            {
                inventory[slotToUse] = new InventorySlot(inventory[slotToUse].item, inventory[slotToUse].count - 1);
            }

            hud.UpdateInventorySlot(slotToUse, inventory[slotToUse]);
        }
    }

    /*private void ScrollLeft()
    {
        if (slotToUse == 0)
        {
            slotToUse = 3;
        }
        else
        {
            slotToUse--;
        }

        Debug.Log("Slot to use: " + slotToUse);
    }

    private void ScrollRight()
    {
        if (slotToUse == 3)
        {
            slotToUse = 0;
        }
        else
        {
            slotToUse++;
        }

        Debug.Log("Slot to use: " + slotToUse);
    }*/

    public struct InventorySlot
    {
        public Item item;
        public int count;

        public InventorySlot (Item _item, int _count)
        {
            item = _item;
            count = _count;
        }
    }
}
