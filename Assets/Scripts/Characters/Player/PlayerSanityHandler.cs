using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerDrivenCharacter))]
public class PlayerSanityHandler : MonoBehaviour, IHaveSanity
{
    private PlayerDrivenCharacter _character;
    private int _currentSanity;

    public event Action<int> OnSanityChanged;
    public static event Action<PlayerDrivenCharacter> OnLowSanity;

    public int CurrentSanity => _currentSanity;
    public int MaxSanity { get; private set; }

    private PlayerSanityStateMachine _stateMachine;

    private void Awake()
    {
        _character = GetComponent<PlayerDrivenCharacter>();
    }

    private void Start()
    {
        _stateMachine = new PlayerSanityStateMachine(_character);
    }

    public void Init(PlayerCharacterStatsSO stats)
    {
        MaxSanity = stats.MaxSanity;
        _currentSanity = MaxSanity;
        ModifySanity(_currentSanity);
    }

    public void ModifySanity(int amount)
    {
        _currentSanity += amount;

        if (_currentSanity < 0)
        {
            _currentSanity = 0;
        }
        if (_currentSanity > MaxSanity)
        {
            _currentSanity = MaxSanity;
        }

        OnSanityChanged?.Invoke(_currentSanity);
        if (_currentSanity <= 25)
            OnLowSanity?.Invoke(_character);
    }
}
