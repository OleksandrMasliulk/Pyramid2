using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

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
        public LocalizedString localizedLine;
        //[TextArea(2, 10)]
        //public string line;
    }

    [System.Serializable]
    public struct DialogueMember
    {
        public LocalizedString localizedName;
        public string name;
        public Sprite image;
    }
}
