using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResurrectPoint : MonoBehaviour, IInterractible
{
    [SerializeField] private string _tooltip;
    public string Tooltip => _tooltip;
    public void Interract(CharacterBase user)
    {
        if (user.HealthHandler is IResurrectible res)
        {
            Debug.Log("REZZ");
            res.Resurrect();
        } 
    }
}
