using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Medkit : Item, IUseOnPress
{
    private int _sanityRestoreValue;

    public Medkit(MedkitSO so) : base(so)
    {
        _sanityRestoreValue = so.restoreAmount;
    }

    private void Heal(IHaveSanity user)
    {
        user.ModifySanity(_sanityRestoreValue);
        Debug.Log("MEDKIT USED");

    }

    public UseItemCallback UseOnPress(CharacterBase user)
    {
        return Use(user);
    }

    public UseItemCallback Use(CharacterBase user)
    {
        if (user.TryGetComponent<IHaveSanity>(out var sanityCharacter))
        {
            Heal(sanityCharacter);
            return new UseItemCallback(UseItemCallback.ResultType.Success);
        }
        else
        {
            Debug.Log("Character has no sanity parameter");
            return new UseItemCallback(UseItemCallback.ResultType.Failed);
        }
    }

}
