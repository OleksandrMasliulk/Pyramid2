using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthHandler : CharacterHealthHandler, IResurrectible
{
    public delegate void PlayerResurrectDelegate();
    public event PlayerResurrectDelegate OnResurrect;

    private PlayerPhysicalStateMachine _stateMachine;

    private void Start()
    {
        _stateMachine = new PlayerPhysicalStateMachine((PlayerDrivenCharacter)_character);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        Die();
    }

    public void Resurrect()
    {
        OnResurrect?.Invoke();
    }
}
