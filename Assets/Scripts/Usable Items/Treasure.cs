using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Treasure : Item
{
    private int value;

    public Treasure(TreasureSO so/*, GameObject prefab*/) : base(so/*, prefab*/)
    {
        this.value = so.value;
    }

    public int GetValue()
    {
        return value;
    }

    public override bool OnButtonPressed(PlayerController user)
    {
        return !UseOnRelease;
    }

    public override bool OnButtonReleased(PlayerController user)
    {
        return UseOnRelease;
    }

    public override void OnDrop(PlayerController user)
    {
    }

    public override void OnPickUp(PlayerController player)
    {
        AudioManager.Instance.PlaySound(AudioManager.Instance.GetSoundBoard<ItemsSoundboard>().pickUpTreasure, 1f);
    }
    public override void Use(PlayerController user)
    {
    }
}
