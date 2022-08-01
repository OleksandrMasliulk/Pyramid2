using UnityEngine;
using System;

public class PlayerInputController : MonoBehaviour {
    public static event Action OnCallUI;

    private PlayerControls _controls;
    public PlayerControls.CharacterControllActions CharacterActions => _controls.CharacterControll;

    private void Awake() {
        _controls = new PlayerControls();

        InitInput();
    }

    private void InitInput() => SwitchToCharacterControl();

    public void SwitchToUI() {
        _controls.CharacterControll.Disable();
        _controls.UI.Enable();
    }

    public void SwitchToCharacterControl() {
        _controls.UI.Disable();
        _controls.CharacterControll.Enable();
    }

    private void CallUI(UnityEngine.InputSystem.InputAction.CallbackContext obj) => OnCallUI?.Invoke();

    private void OnEnable() {
        UIController.OnUISessionStarted += SwitchToUI;
        UIController.OnUISessionEnded += SwitchToCharacterControl;
        CharacterActions.ShowMenu.performed += CallUI;
    }

    private void OnDisable() {
        UIController.OnUISessionStarted -= SwitchToUI;
        UIController.OnUISessionEnded -= SwitchToCharacterControl;
        CharacterActions.ShowMenu.performed -= CallUI;
    }
}
