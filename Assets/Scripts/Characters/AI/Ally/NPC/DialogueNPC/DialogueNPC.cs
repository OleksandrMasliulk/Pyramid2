using UnityEngine;

public class DialogueNPC : NPCBase, IInterractible {
    [SerializeField] private string _tooltip;
    public string Tooltip => _tooltip;
    public Transform ObjectReference => transform;

    [SerializeField] private Dialogue _currentDialogue;

    public override void InitCharacter(CharacterBaseStatsSO stats) {
    }

    public void Interract(CharacterBase user) => DialogueManager.Instance.StartDialogue(_currentDialogue);
}
