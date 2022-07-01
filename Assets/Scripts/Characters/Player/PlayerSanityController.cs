using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerSanityController : MonoBehaviour
{
    private PlayerController playerController;

    public delegate void OnLowSanityDelegate(PlayerController player);
    public event OnLowSanityDelegate OnLowSanity;

    private int _currentSanity;
    public int CurrentSanity => _currentSanity;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _currentSanity = playerController.Stats.MaxSanity;
        UpdateSanity(_currentSanity);
    }

    public void UpdateSanity(int value)
    {
        _currentSanity += value;

        if (_currentSanity < 0)
        {
            _currentSanity = 0;
        }
        if (_currentSanity > 100)
        {
            _currentSanity = 100;
        }

        if (_currentSanity <= 25)
        {
            OnLowSanity?.Invoke(this.playerController);
        }

        playerController.HUDController.UpdateSanitySlider(_currentSanity);
        playerController.GraphicsController.SetSanityFX(_currentSanity);
    }
}
