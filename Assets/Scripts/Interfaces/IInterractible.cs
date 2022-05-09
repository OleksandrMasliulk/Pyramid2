using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInterractible
{
    public string tooltip { get; set; }
    public void Interract(PlayerController user);
}
