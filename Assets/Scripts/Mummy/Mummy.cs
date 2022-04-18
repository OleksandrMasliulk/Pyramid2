using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mummy : MonoBehaviour
{
    private MummyState state;

    public void SetState(MummyState _state)
    {
        state = _state;
        state.SetMummy(this);
    }
}
