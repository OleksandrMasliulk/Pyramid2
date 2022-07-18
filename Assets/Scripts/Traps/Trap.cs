using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trap : MonoBehaviour
{
    [SerializeField] protected int sanityLoss;

    public abstract void Activate(IDamageable target);
    public virtual void ReduceSanity(PlayerDrivenCharacter target)
    {
        //if (target != null)
        //    target.SanityController.UpdateSanity(-sanityLoss);
    }
}
