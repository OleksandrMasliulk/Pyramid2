using System.Collections.Generic;
using UnityEngine;
using System;
using static DialogueSO;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour {
    public static DialogueManager Instance { get; private set; }

    public static event Action OnStartDialogue;
    public static event Action OnEndDialogue;

    public GameObject dialogueWindow;
    public TMP_Text speakerName;
    public Image speakerIcon;
    public TMP_Text line;

    private Queue<DialogueLine> currentLines;
    private Dialogue currentDialogue;

    private void Awake() {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);

        currentLines = new Queue<DialogueLine>();
    }

    public void StartDialogue(Dialogue dialogue) {
        Time.timeScale = 0;
        dialogueWindow.SetActive(true);
        OnStartDialogue?.Invoke();

        currentDialogue = dialogue;
        currentLines.Clear();

        foreach (DialogueLine line in dialogue.dialogueSO.Dialogue)
            currentLines.Enqueue(line);

        DisplayNextLine();
    }

    public void DisplayNextLine(){
        if (currentLines.Count == 0) {
            EndDialogue();
            return;
        }

        DialogueLine dLine = currentLines.Dequeue();
        speakerIcon.sprite = dLine.speaker.image;
        speakerName.enabled = false;
        LocalizationHandler.Instance.GetLocalizedTextAsync(dLine.speaker.localizedName).Completed += (op) => { 
            speakerName.text = op.Result;
            speakerName.enabled = true;
        };
        line.enabled = false;
        LocalizationHandler.Instance.GetLocalizedTextAsync(dLine.localizedLine).Completed += (op) => { 
            line.text = op.Result;
            line.enabled = true;
        };
    }

    public void EndDialogue() {
        Time.timeScale = 1;
        dialogueWindow.SetActive(false);
        OnEndDialogue?.Invoke();
        currentDialogue.dialogueSO.OnDialogueEndEvent?.Invoke();
    }
}
