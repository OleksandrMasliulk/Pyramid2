using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flare : Item
{
    protected override void Init()
    {
        Debug.Log("FLARE CLASEE CONSTRUCTED");
        base.Init();

        isStackable = true;
        isConsumable = true;

        //PATHS
        pickableMirrorPath = "Pickable Items/Pickable Flare";
    }

    public override void Use(PlayerInventoryController user)
    {
        Debug.Log("FLARE USED");
        base.Use(user);

        Throw(user);
    }

    private void Throw(PlayerInventoryController user)
    {
        var prefab = Resources.Load("Usable Items/Flare");
        if (prefab == null)
        {
            Debug.Log("No FLARE RESOURCE found");
            return;
        }

        MonoBehaviour.Instantiate((GameObject)prefab, user.transform.position, Quaternion.identity);
    }
}
