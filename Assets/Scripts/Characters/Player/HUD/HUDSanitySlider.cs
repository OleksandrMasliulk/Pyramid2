using UnityEngine;
using UnityEngine.UI;

public class HUDSanitySlider : MonoBehaviour {
    [SerializeField] private Slider _slider;
    [SerializeField] private Image _fill;

    [SerializeField] private Color _color100;
    [SerializeField] private Color _color75;
    [SerializeField] private Color _color50;
    [SerializeField] private Color _color25;

    private PlayerDrivenCharacter _player;

    public void InitSanityHUD(PlayerDrivenCharacter player) {
        _player = player;

        ModifySlider(100);

        player.SanityHandler.OnSanityChanged += ModifySlider;
    }

    public void ModifySlider(int amount) {
        if (amount > _slider.maxValue)
            amount = (int)_slider.maxValue;
        else if (amount < _slider.minValue)
            amount = (int)_slider.minValue;
        _slider.value = amount;

        HandleColor(amount);
    }

    private void HandleColor(int amount) {
        int sliderRange = (int)(_slider.maxValue - _slider.minValue);

        if (amount > sliderRange * .75f)
            _fill.color = _color100;
        else if (amount <= sliderRange * .75f && amount > sliderRange * .5f)
            _fill.color = _color75;
        else if (amount <= sliderRange * .5f && amount > sliderRange * .25f)
            _fill.color = _color50;
        else if (amount <= sliderRange * .25f)
            _fill.color = _color25;
    }

    private void OnDestroy() => _player.SanityHandler.OnSanityChanged -= ModifySlider;
}
