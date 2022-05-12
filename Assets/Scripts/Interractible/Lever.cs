using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Lever : MonoBehaviour, IInterractible
{
    [SerializeField]private RemoteInterractComponent objToInterract;
    [SerializeField] private Animator anim;
    private bool isOn;

    public string tooltip { get; set; }

    private void Start()
    {
        tooltip = "Press E to Interract";
        isOn = false;
        anim.SetBool("On", isOn);
    }

    public void Interract(PlayerController user)
    {
        objToInterract.Interract(user);
        isOn = !isOn;
        anim.SetBool("On", isOn);
    }
}
