using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DialogueSO;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    public delegate void OnStartDialogueDelegate();
    public static event OnStartDialogueDelegate OnStartDialogue;
    public delegate void OnEndDialogueDelegate();
    public static event OnEndDialogueDelegate OnEndDialogue;

    private Queue<DialogueLine> currentDialogue;

    public GameObject dialogueWindow;
    public Text speakerName;
    public Image speakerIcon;
    public Text line;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        currentDialogue = new Queue<DialogueLine>();
    }

    public void StartDialogue(DialogueSO dialogueSO)
    {
        Time.timeScale = 0;
        dialogueWindow.SetActive(true);
        OnStartDialogue?.Invoke();

        currentDialogue.Clear();

        foreach (DialogueLine line in dialogueSO.dialogue)
        {
            currentDialogue.Enqueue(line);
        }

        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (currentDialogue.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine dLine = currentDialogue.Dequeue();
        speakerIcon.sprite = dLine.speaker.image;
        speakerName.text = dLine.speaker.name;
        line.text = dLine.line;
    }

    public void EndDialogue()
    {
        Time.timeScale = 1;
        dialogueWindow.SetActive(false);
        OnEndDialogue?.Invoke();
    }
}
