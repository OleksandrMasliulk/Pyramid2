using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HUBMap : MonoBehaviour, IInterractible
{
    [SerializeField] private string _tooltip;
    public string Tooltip => _tooltip;

    public Transform ObjectReference => transform;

    [SerializeField] private UnityEvent OnMapUsed;

    public void Interract(CharacterBase user)
    {
        if (user is PlayerDrivenCharacter)
            OnMapUsed?.Invoke();
    }
}
