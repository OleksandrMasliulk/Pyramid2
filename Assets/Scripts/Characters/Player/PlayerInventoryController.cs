using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerInventoryController : MonoBehaviour
{
    private PlayerController playerController;

    private InventorySlot[] inventory;
    private const int inventorySlots = 4;

    private int slotToUse;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Start()
    {
        inventory = new InventorySlot[inventorySlots];
        slotToUse = 0;
        SwitchSlot(slotToUse);

        for (int i = 0; i < inventorySlots; i++)
        {
            playerController.HUDController.UpdateInventorySlot(i, inventory[i]);
        }
    }

    private void Update()
    {
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
    }

    public void UseButtonPress()
    {
        if (inventory[slotToUse].item == null)
        {
            Debug.Log("Slot is empty");

            return;
        }
        if (inventory[slotToUse].item.OnButtonPressed(playerController))
        {
            UseItem();
        }
    }

    public void UseButtonRelease()
    {
        if (inventory[slotToUse].item == null)
        {
            Debug.Log("Slot is empty");

            return;
        }
        if (inventory[slotToUse].item.OnButtonReleased(playerController))
        {
            UseItem();
        }
    }

    public bool AddToInventory(Item item, int count, GameObject dropPrefab)
    {
        if (item.IsStackable)
        {
            for (int i = 0; i < inventorySlots; i++)
            {
                if (inventory[i].item != null && inventory[i].item.ID == item.ID && inventory[i].count < item.MaxStack)
                {
                    inventory[i] = new InventorySlot(item, inventory[i].count + count, dropPrefab);
                    Debug.Log("Stacked");

                    playerController.HUDController.UpdateInventorySlot(i, inventory[i]);

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
                    inventory[i] = new InventorySlot(item, count, dropPrefab);
                    Debug.Log("Item added");

                    playerController.HUDController.UpdateInventorySlot(i, inventory[i]);

                    switch (item.Type)
                    {
                        default:
                            AudioManager.PlaySound(AudioManager.Sound.PickUpItem, 1f);
                            break;
                        case (Item.ItemType.Treasure):
                            AudioManager.PlaySound(AudioManager.Sound.PickUpTreasure, 1f);
                            break;
                    }

                    return true;
                }
            }
        }

        return false;
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
        //if (inventory[slotToUse].item == null)
        //{
        //    Debug.Log("Slot is empty");

        //    return;
        //}

        //inventory[slotToUse].item.Use(playerController);

        if (inventory[slotToUse].item.IsConsumable)
        {
            int newCount = inventory[slotToUse].count - 1;

            if (newCount == 0)
            {
                inventory[slotToUse] = new InventorySlot(null, 0, null);
            }
            else
            {
                inventory[slotToUse] = new InventorySlot(inventory[slotToUse].item, inventory[slotToUse].count - 1, inventory[slotToUse].dropPrefab);
            }

            playerController.HUDController.UpdateInventorySlot(slotToUse, inventory[slotToUse]);
        }
    }



    private void SwitchSlot(int num)
    {
        slotToUse = num;
        Debug.Log("Slot to use: " + num);

        if (playerController.HUDController != null)
        {
            playerController.HUDController.HighlightInventorySlot(num);
        }
    }

    public void Drop()
    {
        if (inventory[slotToUse].item == null)
        {
            Debug.Log("Slot is empty");

            return;
        }
        else
        {
            Pickable itemDropped = Instantiate(inventory[slotToUse].dropPrefab, transform.position, Quaternion.identity).GetComponent<Pickable>();
            itemDropped.SetCount(inventory[slotToUse].count);

            inventory[slotToUse].item.OnDrop(playerController);
            inventory[slotToUse] = new InventorySlot(null, 0, null);

            playerController.HUDController.UpdateInventorySlot(slotToUse, inventory[slotToUse]);
        }
    }
    public void Drop(int slotIndex)
    {
        if (inventory[slotIndex].item == null)
        {
            Debug.Log("Slot is empty");

            return;
        }
        else
        {
            Pickable itemDropped = Instantiate(inventory[slotIndex].dropPrefab, transform.position, Quaternion.identity).GetComponent<Pickable>();
            itemDropped.SetCount(inventory[slotIndex].count);

            inventory[slotIndex].item.OnDrop(playerController);
            inventory[slotIndex] = new InventorySlot(null, 0, null);

            playerController.HUDController.UpdateInventorySlot(slotIndex, inventory[slotIndex]);
        }
    }

    public Item GetItemFromSlot(int slot)
    {
        if (slot > inventorySlots - 1)
            return null;

        return inventory[slot].item;
    }

    public struct InventorySlot
    {
        public Item item;
        public int count;
        public GameObject dropPrefab;

        public InventorySlot (Item _item, int _count, GameObject _dropPrefab)
        {
            item = _item;
            count = _count;
            dropPrefab = _dropPrefab;
        }
    }

    public void DropWholeInventory()
    {
        for (int i = 0; i < inventorySlots; i++)
        {
            Drop(i);
        }
    }
}
