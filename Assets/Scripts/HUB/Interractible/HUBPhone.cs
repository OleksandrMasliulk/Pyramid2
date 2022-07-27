using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HUBPhone : MonoBehaviour, IInterractible
{
    [SerializeField] private string _tooltip;
    public string Tooltip => _tooltip;

    [SerializeField] private UnityEvent OnPhoneEvent;

    public Transform ObjectReference => transform;

    public void Interract(CharacterBase user)
    {
        if (user is PlayerDrivenCharacter)
            OnPhoneEvent?.Invoke();
    }

}
