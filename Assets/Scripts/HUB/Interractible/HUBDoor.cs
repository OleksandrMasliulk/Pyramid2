using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HUBDoor : MonoBehaviour, IInterractible
{
    [SerializeField] private string _tooltip;
    public string Tooltip => _tooltip;

    public Transform ObjectReference => transform;

    [SerializeField] private UnityEvent OnDoor;

    public void Interract(CharacterBase user)
    {
        if (user is PlayerDrivenCharacter)
            OnDoor?.Invoke();
    }
}
