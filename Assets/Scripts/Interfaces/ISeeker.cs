using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface ISeeker<T>
{
    public LayerMask Layer { get; }
    public List<T> ObjectsSeeked { get; }

    public event Action<T> OnSeeked;
    public event Action<T> OnLost;
}
