using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCheckpoint : MonoBehaviour, IInterractible
{
    public TutorialController tutController;

    public string Tooltip { get; set; }

    private void Start()
    {
        Tooltip = "RESURRECT";
    }

    public void Interract(PlayerController user)
    {
        tutController.ResurrectPlayer(this.transform);
    }
}
