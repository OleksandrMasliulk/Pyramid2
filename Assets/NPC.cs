using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInterractible
{
    public string tooltip { get; set; }

    [SerializeField] private Dialogue currentDialogue;

    private void Awake()
    {
        tooltip = "Press E to Speak";
    }

    public void Interract(PlayerController user)
    {
        DialogueManager.Instance.StartDialogue(currentDialogue);
    }
}
