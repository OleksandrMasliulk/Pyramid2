using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyGraphicsController : CharacterGraphicsController
{
    public void SetStunned(bool value)
    {
        _animator.SetBool("Stunned", value);
    }
}
