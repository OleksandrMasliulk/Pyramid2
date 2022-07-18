using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerDrivenCharacter))]
public class PlayerSanityHandler : MonoBehaviour, IHaveSanity
{
    private PlayerDrivenCharacter _character;

    public delegate void OnLowSanityDelegate(IHaveSanity player);
    public event OnLowSanityDelegate OnLowSanity;

    private int _currentSanity;
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

        if (_currentSanity <= MaxSanity * .25f)
        {
            OnLowSanity?.Invoke(this);
        }

        _character.HUDHandler.SanitySlider.ModifySlider(_currentSanity);
        //playerController.GraphicsController.SetSanityFX(_currentSanity);
    }
}
