using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthHandler : CharacterHealthHandler, IResurrectible
{
    public delegate void PlayerResurrectDelegate();
    public event PlayerResurrectDelegate OnResurrect;
    [SerializeField] private GameEvent OnPlayerDied;


    private PlayerPhysicalStateMachine _stateMachine;

    private void Start()
    {
        _stateMachine = new PlayerPhysicalStateMachine((PlayerDrivenCharacter)_character);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        Die();
        OnPlayerDied?.Invoke();
    }

    public void Resurrect()
    {
        OnResurrect?.Invoke();
    }
}
