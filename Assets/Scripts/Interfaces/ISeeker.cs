using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface ISeeker<T>
{
    public List<T> ObjectsSeeked { get; }

    public event Action OnSeeked;
    public event Action OnLost;
}
