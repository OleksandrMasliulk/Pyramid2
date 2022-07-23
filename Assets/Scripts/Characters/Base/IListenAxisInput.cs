using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IListenAxisInput
{
    public float Horizontal { get; }
    public float Vertical { get; }
    public void ReadInput();
}
