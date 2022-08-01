using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInterractionHandler : MonoBehaviour {
    private PlayerDrivenCharacter _character;
    //[SerializeField] private Seeker_InterractibleTriggerCircle _seeker;

    private void Awake() => _character = GetComponent<PlayerDrivenCharacter>();

    public void Interract(InputAction.CallbackContext context) {
        if (_character.Selector.SelectedItem == null)
            return;

        _character.Selector.SelectedItem.Interract(_character);
    }


    private void OnEnable() => _character.InputController.CharacterActions.Interract.performed += Interract;

    private void OnDisable() => _character.InputController.CharacterActions.Interract.performed -= Interract;
}
