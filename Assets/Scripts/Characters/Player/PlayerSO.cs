using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Characters/Players/New Player")]
public class PlayerSO : CharacterBaseSO
{
    [Header("Stats")]
    [SerializeField] private PlayerStats playerStats;
    protected override CharacterStats GetSpecificStats()
    {
        return playerStats;
    }
}
