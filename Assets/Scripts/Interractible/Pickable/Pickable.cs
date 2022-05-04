using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : Interractible
{
    public enum ItemType
    {
        Flare,
        Medkit,
        Flashlight,
        Paint,
        Treasure
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
            case ItemType.Paint:
                item = new Paint();
                break;
            case ItemType.Treasure:
                item = new PickableTreasure();
                break;
        }

        if (!item.isStackable)
        {
            count = 1;
        }
    }

    protected override void Action(PlayerController user)
    {
        base.Action(user);

        if (PickUp(user))
        {
            isActive = false;
            Destroy(this.gameObject);
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
}
