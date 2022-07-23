using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanSense
{
    public float SenseMoveSpeed { get; }
    public CharacterBase Target { get; }
}
