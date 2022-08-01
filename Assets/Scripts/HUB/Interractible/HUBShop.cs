using UnityEngine;
using UnityEngine.Events;

public class HUBShop : MonoBehaviour, IInterractible {
    public Transform ObjectReference => transform;

    [SerializeField] private string _tooltip;
    public string Tooltip => _tooltip;
    [SerializeField] private UnityEvent OnShop;

    public void Interract(CharacterBase user) {
        if (user is PlayerDrivenCharacter)
            OnShop?.Invoke();
    }
}
