using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HUBAchievments : MonoBehaviour, IInterractible
{
    [SerializeField] private string _tooltip;
    public string Tooltip => _tooltip;

    public Transform ObjectReference => transform;

    [SerializeField] private UnityEvent OnAchievments;

    public void Interract(CharacterBase user)
    {
        if (user is PlayerDrivenCharacter)
            OnAchievments?.Invoke();
    }

}
