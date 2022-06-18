using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Flare", menuName = "Items/Flares/New Flare")]
public class FlareSO : ItemSO
{
    [Header("Item Parameters")]
    public Flare flare;

    public override Item GetItem()
    {
        return flare;
    }
}
