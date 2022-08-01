using UnityEngine;

[CreateAssetMenu(fileName = "New Player Character", menuName = "Characters/New Player Character")]
public class PlayerCharacterStatsSO : CharacterBaseStatsSO {
    [SerializeField] private int _maxSanity;
    public int MaxSanity => _maxSanity;

    [SerializeField] private int _slotCount;
    public int SlotCount => _slotCount;

    private void OnValidate() {
        if (_slotCount < 0)
            _slotCount = 0;
    }
}
