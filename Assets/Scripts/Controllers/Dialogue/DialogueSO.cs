using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName ="New Dialogue", menuName = "Dialogues/New Dialogue")]
public class DialogueSO : ScriptableObject {
    [SerializeField] private DialogueMember[] _dialogueMembers;
    public DialogueMember[] Members => _dialogueMembers;
    [SerializeField] private DialogueLine[] _dialogue;
    public DialogueLine[] Dialogue => _dialogue;
    [SerializeField] private GameEvent _dialogueEndEvent;
    public GameEvent OnDialogueEndEvent => _dialogueEndEvent;

    [System.Serializable]
    public class DialogueLine  {
        [Dropdown("_dialogueMembers", "name")]
        public DialogueMember speaker;
        public LocalizedString localizedLine;
    }

    [System.Serializable]
    public struct DialogueMember {
        public LocalizedString localizedName;
        public string name;
        public Sprite image;
    }
}
