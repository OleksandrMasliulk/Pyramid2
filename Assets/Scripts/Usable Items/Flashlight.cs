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
        useOnRelease = false;

        //PATHS
        pickableMirrorPath = "Pickable Items/Pickable Flashlight";

        isActive = false;
    }

    public override void Use(PlayerController user)
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
