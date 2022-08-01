using System;
using UnityEngine;

[RequireComponent(typeof(PlayerDrivenCharacter))]
public class PlayerSanityHandler : MonoBehaviour, IHaveSanity {
    public event Action<int> OnSanityChanged;
    public static event Action<PlayerDrivenCharacter> OnLowSanity;
    public int MaxSanity { get; private set; }

    private int _currentSanity;
    public int CurrentSanity => _currentSanity;
    private PlayerDrivenCharacter _character;
    private PlayerSanityStateMachine _stateMachine;

    private void Awake()
    {
        _character = GetComponent<PlayerDrivenCharacter>();
        _stateMachine = new PlayerSanityStateMachine(_character);
    }

    public void Init(PlayerCharacterStatsSO stats) {
        MaxSanity = stats.MaxSanity;
        _currentSanity = MaxSanity;
        ModifySanity(_currentSanity);
    }

    public void ModifySanity(int amount) {
        _currentSanity += amount;

        if (_currentSanity < 0)
            _currentSanity = 0;
        if (_currentSanity > MaxSanity)
            _currentSanity = MaxSanity;

        OnSanityChanged?.Invoke(_currentSanity);
        if (_currentSanity <= 25)
            OnLowSanity?.Invoke(_character);
    }
}
