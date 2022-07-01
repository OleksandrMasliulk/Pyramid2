using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Flashlight : Item
{
    private bool isActive;

    public Flashlight(FlashlightSO so/*, GameObject prefab*/) : base(so/*, prefab*/)
    {
        isActive = false;
    }

    public override void Use(PlayerController user)
    {
        Debug.Log("Flashlight USED");

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

        user.GraphicsController.SwitchFlashlight(true);
    }

    public override void OnDrop(PlayerController user)
    {
        TurnOff(user);
    }

    private void TurnOff(PlayerController user)
    {
        isActive = false;
        Debug.Log("Flashlight turned OFF");

        user.GraphicsController.SwitchFlashlight(false);
    }

    public override bool OnButtonPressed(PlayerController user)
    {
        Use(user);

        return !UseOnRelease;
    }

    public override bool OnButtonReleased(PlayerController user)
    {
        return UseOnRelease;
    }
}
