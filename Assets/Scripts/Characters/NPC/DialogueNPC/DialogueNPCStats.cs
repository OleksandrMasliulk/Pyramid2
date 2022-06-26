using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueNPCStats : CharacterStats
{
    [SerializeField] private Dialogue _dialogue;
    public Dialogue Dialogue => _dialogue;
}
