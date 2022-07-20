using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanChase
{
    public float LineOfSightRadius { get; }
    public float ChaseSpeed { get; }
    public CharacterBase Target { get; }
}
