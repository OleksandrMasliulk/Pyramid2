using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flare : Item
{
    private GameObject flarePrefab;

    public Flare(FlareSO so/*, GameObject prefab*/) : base(so/*, prefab*/)
    {
        flarePrefab = so.flareToDropPb;
    }

    public override void Use(PlayerController user)
    {
        Throw(user);
    }

    private void Throw(PlayerController user)
    {
        MonoBehaviour.Instantiate(flarePrefab, user.transform.position, Quaternion.identity);
    }

    public override bool OnButtonPressed(PlayerController user)
    {
        Use(user);

        return !UseOnRelease;
    }

    public override bool OnButtonReleased(PlayerController user)
    {
        return UseOnRelease;
    }

    public override void OnDrop(PlayerController user)
    {
    }
}
