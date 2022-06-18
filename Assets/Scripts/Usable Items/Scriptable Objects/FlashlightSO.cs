using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Flashlight", menuName = "Items/Flashlights/New Flashlight")]
public class FlashlightSO : ItemSO
{
    [Header("Item Parameters")]
    public Flashlight flashlight;

    public override Item GetItem()
    {
        return flashlight;
    }
}
