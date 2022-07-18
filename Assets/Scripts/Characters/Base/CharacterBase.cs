using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public abstract class CharacterBase : MonoBehaviour
{
    [SerializeField] protected CharacterVFXHandler _vfxHandler;
    public CharacterVFXHandler VFXHandler => _vfxHandler;
    [SerializeField] protected CharacterAnimationHandler _animationHandler;
    public CharacterAnimationHandler AnimationHandler => _animationHandler;
    public abstract void InitCharacter(AssetReference stats);
}