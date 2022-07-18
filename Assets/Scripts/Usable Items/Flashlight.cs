using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Flashlight : Item, IItemPickUp, IItemDrop, IUseOnPress
{
    private bool _isActive;
    private GameObject _flashlight;
    private GameObject _prefab;

    public Flashlight(FlashlightSO so) : base(so)
    {
        _isActive = false;
        _prefab = so.flashlightPrefab;
    }

    private void TurnOn(PlayerDrivenCharacter user)
    {
        _isActive = true;
        Debug.Log("Flashlight turned ON");

        _flashlight.SetActive(true);
    }

    private void TurnOff(PlayerDrivenCharacter user)
    {
        _isActive = false;
        Debug.Log("Flashlight turned OFF");

        _flashlight.SetActive(false);
    }

    public UseItemCallback UseOnPress(CharacterBase user)
    {
        return Use(user);
    }

    public UseItemCallback Use(CharacterBase user)
    {
        Debug.Log("Flashlight USED");

        if (_isActive)
        {
            TurnOff((PlayerDrivenCharacter)user);
        }
        else
        {
            TurnOn((PlayerDrivenCharacter)user);
        }

        return new UseItemCallback(UseItemCallback.ResultType.Success);
    }

    public void OnDrop(CharacterBase user)
    {
        TurnOff((PlayerDrivenCharacter)user);
        MonoBehaviour.Destroy(_flashlight);
    }

    public void OnPickUp(CharacterBase user)
    {
       // _flashlight = MonoBehaviour.Instantiate(_prefab, player.GraphicsController.FlashlightSocket);
    }
}
