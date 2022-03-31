using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableFlare : Pickable
{
    protected override void Init()
    {
        item = new Flare();

        base.Init();
    }
}
