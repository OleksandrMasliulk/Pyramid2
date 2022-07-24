using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealthHandler : MonoBehaviour, IDamageable
{
    private CharacterBase _character;

    public delegate void CharacterDieDelegate(CharacterBase character);
    public event CharacterDieDelegate OnCharacterDie;
    public event Action OnTakeDamage;

    private void Awake()
    {
        _character = GetComponent<CharacterBase>();
    }

    public virtual void TakeDamage(int damage)
    {
        Debug.Log($"{_character.Stats.Name} got hit for {damage} damage");
        OnTakeDamage?.Invoke();
    }

    public virtual void Die()
    {
        Debug.Log($"!!! {_character.Stats.Name} died !!!");
        OnCharacterDie?.Invoke(_character);
    }
}
