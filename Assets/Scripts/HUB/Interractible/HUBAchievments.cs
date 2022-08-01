using UnityEngine;
using UnityEngine.Events;

public class HUBAchievments : MonoBehaviour, IInterractible {
    public Transform ObjectReference => transform;

    [SerializeField] private string _tooltip;
    public string Tooltip => _tooltip;
    [SerializeField] private UnityEvent OnAchievments;

    public void Interract(CharacterBase user)
    {
        if (user is PlayerDrivenCharacter)
            OnAchievments?.Invoke();
    }

}
