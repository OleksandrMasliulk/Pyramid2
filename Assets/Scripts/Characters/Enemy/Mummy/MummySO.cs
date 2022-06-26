using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mummy", menuName = "Characters/Enemies/New Mummy")]
public class MummySO : EnemyBaseSO
{
    [Header("Stats")]
    [SerializeField] private MummyStats mummyStats;
    protected override CharacterStats GetSpecificStats()
    {
        return mummyStats;
    }
}

