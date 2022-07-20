using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInterractible
{
    public string Tooltip { get; }
    public void Interract(PlayerController user);
}
