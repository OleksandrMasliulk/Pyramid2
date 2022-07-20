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

    public int CurrentSanity => _currentSanity;
    public int MaxSanity { get; private set; }

    private void Awake()
    {
        _character = GetComponent<PlayerDrivenCharacter>();
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

        _character.HUDHandler.SanitySlider.ModifySlider(_currentSanity);
        //playerController.GraphicsController.SetSanityFX(_currentSanity);
    }
}
