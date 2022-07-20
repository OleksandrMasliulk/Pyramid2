using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNPC : NPCBase, IInterractible
{
    public string Tooltip { get; set; }

    [SerializeField] private Dialogue currentDialogue;

    private void Awake()
    {
        Tooltip = "SPEAK";
    }

    public void Interract(PlayerController user)
    {
        DialogueManager.Instance.StartDialogue(currentDialogue);
    }

    public override void TakeDamage(int damage)
    {
    }
}
