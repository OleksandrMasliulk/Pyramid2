using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class DialogueNPC : NPCBase, IInterractible
{
    [SerializeField] private string _tooltip;
    public string Tooltip => _tooltip;

    [SerializeField] private Dialogue currentDialogue;

    //public void Interract(PlayerController user)
    //{
    //    DialogueManager.Instance.StartDialogue(currentDialogue);
    //}

    public override void InitCharacter(AssetReference stats)
    {
        throw new System.NotImplementedException();
    }

    public void Interract(CharacterBase user)
    {
    }
}
