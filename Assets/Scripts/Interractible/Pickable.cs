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
        if (itemSO.itemID == -1)
        {
            Debug.LogWarning(name + ": Inavlid ID, object destroyed!");
            Destroy(this.gameObject);
            return;
        }

        switch (itemSO.type) 
        {
            //default:
            //    Destroy(this.gameObject);
            //    break;
            case ItemType.Flare:
                item = new Flare((FlareSO)itemSO/*, dropPrefab*/);
                break;
            case ItemType.Medkit:
                item = new Medkit((MedkitSO)itemSO/*, dropPrefab*/);
                break;
            case ItemType.Flashlight:
                item = new Flashlight((FlashlightSO)itemSO/*, dropPrefab*/);
                break;
            case ItemType.Paint:
                item = new Paint((PaintSO)itemSO/*, dropPrefab*/);
                break;
            case ItemType.Treasure:
                item = new Treasure((TreasureSO)itemSO/*, dropPrefab*/);
                break;
        }

        if (!item.IsStackable)
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
            return inventory.AddToInventory(item, count, itemSO.dropPrefab);
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
