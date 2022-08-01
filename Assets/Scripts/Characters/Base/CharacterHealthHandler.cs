using System;
using UnityEngine;

public class CharacterHealthHandler : MonoBehaviour, IDamageable {
    public event Action<CharacterBase> OnCharacterDie;
    public event Action OnTakeDamage;

    protected CharacterBase _character;

    private void Awake() => _character = GetComponent<CharacterBase>();

    public virtual void TakeDamage(int damage) {
        Debug.Log($"{_character.Stats.Name} got hit for {damage} damage");
        OnTakeDamage?.Invoke();
    }

    public virtual void Die() {
        Debug.Log($"!!! {_character.Stats.Name} died !!!");
        OnCharacterDie?.Invoke(_character);
    }
}
