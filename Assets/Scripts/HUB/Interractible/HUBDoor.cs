using UnityEngine;
using UnityEngine.Events;

public class HUBDoor : MonoBehaviour, IInterractible {
    public Transform ObjectReference => transform;

    [SerializeField] private string _tooltip;
    public string Tooltip => _tooltip;
    [SerializeField] private UnityEvent OnDoor;

    public void Interract(CharacterBase user) {
        if (user is PlayerDrivenCharacter)
            OnDoor?.Invoke();
    }
}
