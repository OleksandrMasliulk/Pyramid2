using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class DialogueNPC : NPCBase, IInterractible
{
    [SerializeField] private string _tooltip;
    public string Tooltip => _tooltip;

    public Transform ObjectReference => transform;

    [SerializeField] private Dialogue currentDialogue;

    public override void InitCharacter(AssetReference stats)
    {
        
    }

    public void Interract(CharacterBase user)
    {
        DialogueManager.Instance.StartDialogue(currentDialogue);
    }
}
