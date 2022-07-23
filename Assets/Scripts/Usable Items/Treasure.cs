using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Treasure : Item
{
    private int _value;

    public Treasure(TreasureSO so) : base(so)
    {
        this._value = so.value;
    }

    public int GetValue()
    {
        return _value;
    }
}
