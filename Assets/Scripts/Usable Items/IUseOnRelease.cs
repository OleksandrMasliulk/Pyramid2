using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUseOnRelease : IUsableItem
{
    public UseItemCallback UseOnRelease(CharacterBase user);
}
