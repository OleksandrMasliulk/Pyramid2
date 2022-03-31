using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableMedicine : Pickable
{
    protected override void Init()
    {
        item = new Medicine();

        base.Init();
    }
}
