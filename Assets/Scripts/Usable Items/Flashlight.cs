using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Flashlight : Item
{
    private bool _isActive;
    private GameObject _flashlight;
    private GameObject _prefab;

    public Flashlight(FlashlightSO so/*, GameObject prefab*/) : base(so/*, prefab*/)
    {
        _isActive = false;
        _prefab = so.flashlightPrefab;
    }

    public override void Use(PlayerController user)
    {
        Debug.Log("Flashlight USED");

        if (_isActive)
        {
            TurnOff(user);
        }
        else
        {
            TurnOn(user);
        }
    }

    private void TurnOn(PlayerController user)
    {
        _isActive = true;
        Debug.Log("Flashlight turned ON");

        _flashlight.SetActive(true);
    }

    private void TurnOff(PlayerController user)
    {
        _isActive = false;
        Debug.Log("Flashlight turned OFF");

        _flashlight.SetActive(false);
    }

    public override void OnPickUp(PlayerController player)
    {
        _flashlight = MonoBehaviour.Instantiate(_prefab, player.GraphicsController.FlashlightSocket);
    }

    public override void OnDrop(PlayerController user)
    {
        TurnOff(user);
        MonoBehaviour.Destroy(_flashlight);
    }

    public override bool OnButtonPressed(PlayerController user)
    {
        Use(user);

        return !UseOnRelease;
    }

    public override bool OnButtonReleased(PlayerController user)
    {
        return UseOnRelease;
    }
}
