using UnityEngine;
using UnityEngine.Events;

public class HUBMap : MonoBehaviour, IInterractible {
    public Transform ObjectReference => transform;

    [SerializeField] private string _tooltip;
    public string Tooltip => _tooltip;
    [SerializeField] private UnityEvent OnMapUsed;

    public void Interract(CharacterBase user) {
        if (user is PlayerDrivenCharacter)
            OnMapUsed?.Invoke();
    }
}
