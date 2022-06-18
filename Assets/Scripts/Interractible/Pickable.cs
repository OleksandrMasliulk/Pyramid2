using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Item;

public class Pickable : MonoBehaviour, IInterractible
{
    [SerializeField] private ItemSO itemSO;
    private Item item;
    public int count;

    public string tooltip { get; set; }

    private void Start()
    {
        tooltip = "Press E to PickUp";

        Init();
    }

    public void Init()
    {
        item = itemSO.GetItem();
        item.dropObject = this.gameObject;


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
