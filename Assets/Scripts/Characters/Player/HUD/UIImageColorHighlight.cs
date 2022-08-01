using UnityEngine;
using UnityEngine.UI;

public class UIImageColorHighlight : MonoBehaviour, IHighlight {
    [SerializeField] private Image _imageToHighlight;
    [SerializeField] private Color _highlightedColor;
    [SerializeField] private Color _baseColor;

    public void Highlight() => _imageToHighlight.color = _highlightedColor;

    public void UnHighlight() => _imageToHighlight.color = _baseColor;
}
