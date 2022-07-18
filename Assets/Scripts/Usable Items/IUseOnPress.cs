using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUseOnPress : IUsableItem
{
    public UseItemCallback UseOnPress(CharacterBase user);
}
