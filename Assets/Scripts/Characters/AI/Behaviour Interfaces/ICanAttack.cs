using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanAttack
{
    public float AttackRange { get; }
    public void Attack(IDamageable target);
}
