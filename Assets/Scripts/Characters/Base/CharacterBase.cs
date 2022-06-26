using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour, IDamageable
{
    public enum CharacterType
    {
        Player,
        AllyNPC,
        Enemy
    }

    private CharacterType _type;
    public CharacterType Type => _type;

    protected CharacterStats _stats;
    public CharacterStats Stats => _stats;

    [SerializeField] protected CharacterGraphicsController _graphicsController;
    public CharacterGraphicsController GraphicsController => _graphicsController;

    public virtual void InitCharacter(CharacterStats stats)
    {
        _stats = stats;
    }

    public abstract void TakeDamage(int damage);
}
