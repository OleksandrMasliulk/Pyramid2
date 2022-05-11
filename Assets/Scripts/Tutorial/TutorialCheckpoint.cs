using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCheckpoint : MonoBehaviour, IInterractible
{
    public TutorialController tutController;

    public string tooltip { get; set; }

    private void Start()
    {
        tooltip = "Press E to Resurrect";
    }

    public void Interract(PlayerController user)
    {
        tutController.ResurrectPlayer(this.transform);
    }
}
