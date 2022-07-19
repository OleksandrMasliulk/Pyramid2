using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthHandler : CharacterHealthHandler
{
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        Die();
    }
}
