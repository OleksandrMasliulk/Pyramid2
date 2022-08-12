using System.Collections.Generic;
using UnityEngine;
using System;
using static DialogueSO;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AddressableAssets;

public class DialogueManager : MonoBehaviour {
    public static DialogueManager Instance { get; private set; }

    public static event Action OnStartDialogue;
    public static event Action OnEndDialogue;

    [SerializeField] private UIPanel _dialogueWindow;
    [SerializeField] private TMP_Text _speakerName;
    [SerializeField] private Image _speakerIcon;
    [SerializeField] private TMP_Text _line;

    private Queue<DialogueLine> _currentLines;
    private DialogueSO _currentDialogue;
    private AssetReference _currentDialogueReference;

    private void Awake() {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);

        _currentLines = new Queue<DialogueLine>();
    }

    public async void StartDialogue(Dialogue dialogue) {
        Time.timeScale = 0;
        _dialogueWindow.EnablePanel();
        OnStartDialogue?.Invoke();

        _currentLines.Clear();
        _currentDialogueReference = dialogue.dialogueReference;
        DialogueSO so = await dialogue.dialogueReference.LoadAssetAsyncSafe<DialogueSO>();
        _currentDialogue = so;
        foreach (DialogueLine line in _currentDialogue.Dialogue)
            _currentLines.Enqueue(line);

        DisplayNextLine();
    }

    public void DisplayNextLine(){
        if (_currentLines.Count == 0) {
            EndDialogue();
            return;
        }

        DialogueLine dLine = _currentLines.Dequeue();
        _speakerIcon.sprite = dLine.speaker.image;
        _speakerName.enabled = false;
        LocalizationHandler.Instance.GetLocalizedTextAsync(dLine.speaker.localizedName).Completed += (op) => { 
            _speakerName.text = op.Result;
            _speakerName.enabled = true;
        };
        _line.enabled = false;
        LocalizationHandler.Instance.GetLocalizedTextAsync(dLine.localizedLine).Completed += (op) => { 
            _line.text = op.Result;
            _line.enabled = true;
        };
    }

    public void EndDialogue() {
        Time.timeScale = 1;
        _dialogueWindow.DisablePanel();
        OnEndDialogue?.Invoke();
        _currentDialogue.OnDialogueEndEvent?.Invoke();
        _currentDialogueReference.ReleaseAssetSafe();
    }
}
