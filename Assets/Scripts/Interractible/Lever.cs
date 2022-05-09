using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Lever : MonoBehaviour, IInterractible
{
    [SerializeField]private RemoteInterractComponent objToInterract;

    public string tooltip { get; set; }

    private void Start()
    {
        tooltip = "Press E to Interract";
    }

    public void Interract(PlayerController user)
    {
        objToInterract.Interract(user);
    }
}
