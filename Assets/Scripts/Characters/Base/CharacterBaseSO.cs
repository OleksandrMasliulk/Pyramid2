using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBaseSO : ScriptableObject
{
    [Header("General")]
    public CharacterBase.CharacterType Type;
    public CharacterBase prefab;
    public CharacterStats Stats => GetSpecificStats();

    protected virtual CharacterStats GetSpecificStats()
    {
        return null;
    }
}
