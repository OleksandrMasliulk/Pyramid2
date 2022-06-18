using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemSO : ScriptableObject
{
    public virtual Item GetItem()
    {
        return null;
    }
}
