using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HUBShop : MonoBehaviour, IInterractible
{
    [SerializeField] private string _tooltip;
    public string Tooltip => _tooltip;

    public Transform ObjectReference => transform;

    [SerializeField] private UnityEvent OnShop;

    public void Interract(CharacterBase user)
    {
        if (user is PlayerDrivenCharacter)
            OnShop?.Invoke();
    }
}
