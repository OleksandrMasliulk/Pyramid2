using UnityEngine;
using UnityEngine.Events;

public class HUBPhone : MonoBehaviour, IInterractible
{
    public Transform ObjectReference => transform;

    [SerializeField] private string _tooltip;
    public string Tooltip => _tooltip;
    [SerializeField] private UnityEvent OnPhoneEvent;

    public void Interract(CharacterBase user) {
        if (user is PlayerDrivenCharacter)
            OnPhoneEvent?.Invoke();
    }

}
