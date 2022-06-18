using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Medkit", menuName = "Items/Medkits/New Medkit")]
public class MedkitSO : ItemSO
{
    [Header("Item Parameters")]
    public Medkit medkit;

    public override Item GetItem()
    {
        return medkit;
    }
}
