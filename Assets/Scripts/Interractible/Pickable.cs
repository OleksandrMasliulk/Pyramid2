using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Item;

public class Pickable : MonoBehaviour, IInterractible
{
    public ItemType type;

    public int count;
    protected Item item;

    public string tooltip { get; set; }

    private void Start()
    {
        tooltip = "Press E to PickUp";

        Init();
    }

    private void Init()
    {
        switch (type)
        {
            case ItemType.Flare:
                item = new Flare();
                break;
            case ItemType.Flashlight:
                item = new Flashlight();
                break;
            case ItemType.Medkit:
                item = new Medicine();
                break;
            case ItemType.Paint:
                item = new Paint();
                break;
            case ItemType.Treasure5:
                item = new Treasure(ItemType.Treasure5);
                break;
            case ItemType.Treasure10:
                item = new Treasure(ItemType.Treasure10);
                break;
        }

        if (!item.isStackable)
        {
            count = 1;
        }
    }

    private bool PickUp(PlayerController user)
    {
        PlayerInventoryController inventory = user.GetPlayerInventoryController();

        if (inventory == null)
        {
            Debug.Log("No INVENTORY CONTROLLER found");
            return false;
        }
        else
        {
            return inventory.AddToInventory(item, count);
        }
    }

    public void Interract(PlayerController user)
    {
        if (PickUp(user))
        {
            Destroy(this.gameObject);
        }
    }
}
