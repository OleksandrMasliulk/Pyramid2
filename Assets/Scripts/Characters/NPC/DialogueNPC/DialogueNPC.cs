using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNPC : NPCBase, IInterractible
{
    public string tooltip { get; set; }

    [SerializeField] private Dialogue currentDialogue;

    private void Awake()
    {
        tooltip = "SPEAK";
    }

    public void Interract(PlayerController user)
    {
        DialogueManager.Instance.StartDialogue(currentDialogue);
    }

    public override void TakeDamage(int damage)
    {
    }
}
