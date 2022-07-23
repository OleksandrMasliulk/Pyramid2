using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyAnimationHandler : CharacterAnimationHandler
{
    private Mummy _mummy;

    private void Awake()
    {
        _mummy = GetComponent<Mummy>();
    }

    public override void SetMovementDirection(Vector2 direction)
    {
        base.SetMovementDirection(direction);

        //if (_mummy.MovementController.CanMove)
        //    AudioManager.Instance.PlayerSound3D(AudioManager.Instance.GetSoundBoard<MummySoundBoard>().walk, transform.position, .2f);
    }
    public void SetStunned(bool value)
    {
        _animator.SetBool("Stunned", value);
    }
}
