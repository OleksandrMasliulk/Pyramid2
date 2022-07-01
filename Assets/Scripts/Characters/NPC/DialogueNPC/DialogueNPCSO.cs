using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue NPC", menuName = "Characters/NPC/New Dialogue NPC")]
public class DialogueNPCSO : NPCBaseSO
{
    [Header("Stats")]
    public DialogueNPCStats dialogueNPCStats;

    protected override CharacterStats GetSpecificStats()
    {
        return dialogueNPCStats;
    }
}
