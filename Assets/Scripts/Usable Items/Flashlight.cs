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
            TurnOff(user);
        }
        else
        {
            TurnOn(user);
        }
    }

    private void TurnOn(PlayerController user)
    {
        isActive = true;
        Debug.Log("Flashlight turned ON");

        user.GetPlayerGraphicsController().SwitchFlashlight(true);
    }

    public override void OnDrop(PlayerController user)
    {
        TurnOff(user);
    }

    private void TurnOff(PlayerController user)
    {
        isActive = false;
        Debug.Log("Flashlight turned OFF");

        user.GetPlayerGraphicsController().SwitchFlashlight(false);
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
