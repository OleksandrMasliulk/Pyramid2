using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : Interractible
{
    public enum ItemType
    {
        Flare,
        Medkit,
        Flashlight
    }

    public ItemType type;

    public int count;
    protected Item item;

    protected override void Init()
    {
        base.Init();

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
        }

        if (!item.isStackable)
        {
            count = 1;
        }
    }

    protected override void Action(PlayerInterractionController user)
    {
        base.Action(user);

        if (PickUp(user))
        {
            isActive = false;
            Destroy(this.gameObject);
        }
    }

    private bool PickUp(PlayerInterractionController user)
    {
        PlayerInventoryController inventory = user.GetComponent<PlayerInventoryController>();

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
}
