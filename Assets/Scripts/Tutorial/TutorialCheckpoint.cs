using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCheckpoint : MonoBehaviour, IInterractible
{
    public TutorialController tutController;

    [SerializeField] private string _tooltip;
    public string Tooltip => _tooltip;

    public void Interract(PlayerDrivenCharacter user)
    {
        tutController.ResurrectPlayer(this.transform);
    }

    public void Interract(CharacterBase user)
    {
        throw new System.NotImplementedException();
    }
}
