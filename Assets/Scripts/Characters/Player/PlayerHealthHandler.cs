using UnityEngine;
using System;

public class PlayerHealthHandler : CharacterHealthHandler, IResurrectible {
    public static event Action<PlayerDrivenCharacter> OnResurrect;
    public static event Action<PlayerDrivenCharacter> OnPlayerDied;

    [SerializeField] private GameEvent PlayerDied;

    private PlayerPhysicalStateMachine _stateMachine;

    private void Start() => _stateMachine = new PlayerPhysicalStateMachine((PlayerDrivenCharacter)_character);

    public override void TakeDamage(int damage) {
        base.TakeDamage(damage);

        Die();
    }

    public override void Die() {
        base.Die();
        
        PlayerDied?.Invoke();
        OnPlayerDied?.Invoke((PlayerDrivenCharacter)_character);
    }

    public void Resurrect() { 
        _stateMachine.SetState(_stateMachine.AliveState);
        OnResurrect?.Invoke((PlayerDrivenCharacter)_character);
    }
}
