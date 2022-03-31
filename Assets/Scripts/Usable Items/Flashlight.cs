using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : Item
{
    private bool isActive;

    protected override void Init()
    {
        Debug.Log("FLASHLIGH CLASEE CONSTRUCTED");
        base.Init();

        isStackable = false;
        isConsumable = false;

        //PATHS
        pickableMirrorPath = "Pickable Items/Pickable Flashlight";

        isActive = false;
    }

    public override void Use(PlayerInventoryController user)
    {
        Debug.Log("Flashlight USED");
        base.Use(user);

        if (isActive)
        {
            TurnOff();
        }
        else
        {
            TurnOn();
        }
    }

    private void TurnOn()
    {
        isActive = true;
        Debug.Log("Flashlight turned ON");
    }

    private void TurnOff()
    {
        isActive = false;
        Debug.Log("Flashlight turned OFF");
    }
}
