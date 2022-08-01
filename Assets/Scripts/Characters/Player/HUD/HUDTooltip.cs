using UnityEngine;
using TMPro;

public class HUDTooltip : MonoBehaviour {
    [SerializeField] private TMP_Text _text;

    public void ShowTooltip(string textKey) {
        Hide();

        var op = LocalizationHandler.Instance.GetLocalizedTextAsync(LocalizationHandler.Tables.TOOLTIPS, textKey);
        op.Completed += (op) => {
            _text.text = op.Result;
            Show();
        };
    }

    public void Show() => _text.enabled = true;

    public void Hide() => _text.enabled = false;
}
