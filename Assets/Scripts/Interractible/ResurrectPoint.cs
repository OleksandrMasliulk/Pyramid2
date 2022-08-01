using UnityEngine;

public class ResurrectPoint : MonoBehaviour, IInterractible
{
    public Transform ObjectReference => transform;

    [SerializeField] private string _tooltip;
    public string Tooltip => _tooltip;

    public void Interract(CharacterBase user) {
        Debug.Log(user.Stats.Name);
        if (user.HealthHandler is IResurrectible res) {
            Debug.Log("REZZ");
            res.Resurrect();
        } 
    }
}
