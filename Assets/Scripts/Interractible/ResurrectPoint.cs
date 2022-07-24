using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResurrectPoint : MonoBehaviour, IInterractible
{
    [SerializeField] private string _tooltip;
    public string Tooltip => _tooltip;

    public Transform ObjectReference => transform;

    public void Interract(CharacterBase user)
    {
        Debug.Log(user.Stats.Name);
        if (user.HealthHandler is IResurrectible res)
        {
            Debug.Log("REZZ");
            res.Resurrect();
        } 
    }
}
