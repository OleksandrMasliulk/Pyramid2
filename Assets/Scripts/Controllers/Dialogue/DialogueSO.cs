using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Dialogue", menuName = "Dialogues/New Dialogue")]
public class DialogueSO : ScriptableObject
{
    [SerializeField] public DialogueMember[] dialogueMembers;
    [SerializeField] public DialogueLine[] dialogue;

    [System.Serializable]
    public class DialogueLine 
    {
        [Dropdown("dialogueMembers", "name")]
        public DialogueMember speaker;

        [TextArea(2, 10)]
        public string line;
    }

    [System.Serializable]
    public struct DialogueMember
    {
        public string name;
        public Sprite image;
    }
}
