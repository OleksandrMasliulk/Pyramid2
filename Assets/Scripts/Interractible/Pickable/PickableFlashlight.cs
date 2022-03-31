using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableFlashlight : Pickable
{
    protected override void Init()
    {
        item = new Flashlight();

        base.Init();
    }
}
