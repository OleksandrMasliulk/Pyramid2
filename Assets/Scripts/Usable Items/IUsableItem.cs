using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUsableItem
{
    public UseItemCallback Use(CharacterBase user);
}
