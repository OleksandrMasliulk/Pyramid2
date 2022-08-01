using UnityEngine;

public class UpscaleHighlight : MonoBehaviour, IHighlight {
    private Vector3 _baseScale;
    [SerializeField] private float _highlightScaleMod;

    private void Awake() => _baseScale = transform.localScale;

    public void Highlight() => transform.localScale *= _highlightScaleMod;

    public void UnHighlight() => transform.localScale = _baseScale;
}
