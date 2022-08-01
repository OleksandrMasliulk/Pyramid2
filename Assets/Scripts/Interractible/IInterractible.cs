using UnityEngine;

public interface IInterractible {
    public string Tooltip { get; }
    public Transform ObjectReference { get; }
    public void Interract(CharacterBase user);
}
