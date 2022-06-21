using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Treasure", menuName = "Items/Treasures/New Treasure")]
public class TreasureSO : ItemSO
{
    [Header("Item Parameters")]
    public int value;
}
