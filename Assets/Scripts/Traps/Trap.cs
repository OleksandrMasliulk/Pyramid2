using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trap : MonoBehaviour
{
    public const float DefaultTickTime = .25f;

    [SerializeField] protected int sanityLoss;

    public abstract void Trigger();
}
