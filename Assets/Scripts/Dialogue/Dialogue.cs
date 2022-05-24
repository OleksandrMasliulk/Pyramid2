using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Dialogue
{
    public DialogueSO dialogueSO;
    public UnityEvent OnDialogueEndEvent;
}
