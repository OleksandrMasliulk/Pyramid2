using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IInventoryInput 
{
    public event Action OnSlot1;
    public event Action OnSlot2;
    public event Action OnSlot3;
    public event Action OnSlot4;
    public event Action OnUsePress;
    public event Action OnUseRelease;
    public event Action OnDrop;
}
