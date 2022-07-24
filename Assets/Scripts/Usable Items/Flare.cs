using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flare : Item, IUseOnPress
{
    private GameObject _flarePrefab;

    public Flare(FlareSO so) : base(so)
    {
        _flarePrefab = so.flareToDropPb;
    }

    private void Throw(CharacterBase user)
    {
        Debug.Log("FLARE used");
        MonoBehaviour.Instantiate(_flarePrefab, user.transform.position, Quaternion.identity);
    }

    public UseItemCallback UseOnPress(CharacterBase user)
    {
        return Use(user);
    }

    public UseItemCallback Use(CharacterBase user)
    {
        Throw(user);
        return new UseItemCallback(UseItemCallback.ResultType.Success);
    }
}
