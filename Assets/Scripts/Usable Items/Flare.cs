using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flare : Item
{
    public Flare()
    {
        Debug.Log("FLARE CLASEE CONSTRUCTED");

        this.type = ItemType.Flare;
        ItemAssets.Instance.GetItem(type, out pickableMirror, out inventoryImage);

        useOnRelease = false;
        isConsumable = true;
        isStackable = true;
    }

    public override void Use(PlayerController user)
    {
        Debug.Log("FLARE USED");
        base.Use(user);

        Throw(user);
    }

    private void Throw(PlayerController user)
    {
        var prefab = Resources.Load("Usable Items/Flare");
        if (prefab == null)
        {
            Debug.Log("No FLARE RESOURCE found");
            return;
        }

        MonoBehaviour.Instantiate((GameObject)prefab, user.transform.position, Quaternion.identity);
    }

    public override bool OnButtonPressed(PlayerController user)
    {
        Use(user);

        return base.OnButtonPressed(user);
    }

    public override bool OnButtonReleased(PlayerController user)
    {
        return base.OnButtonReleased(user);
    }
}
