using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats : CharacterStats
{
    [SerializeField] private float _walkSpeed;
    public float WalkSpeed => WalkSpeed;

    [SerializeField] private int _maxSanity;
    public int MaxSanity => _maxSanity;

    [SerializeField] private bool _isGhost;
    public bool IsGhost => _isGhost;

    [SerializeField] private bool _isCovered;
    public bool IsCovered => _isCovered;

    public void SetGhost(bool newValue)
    {
        _isGhost = newValue;
    }
    public void SetCovered(bool newValue)
    {
        _isCovered = newValue;
    }
}
