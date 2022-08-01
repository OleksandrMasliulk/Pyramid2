using UnityEngine;
using UnityEngine.AddressableAssets;

public abstract class CharacterBase : MonoBehaviour {
    protected CharacterBaseStatsSO _stats;
    public CharacterBaseStatsSO Stats => _stats;
    protected CharacterHealthHandler _healthHandler;
    public CharacterHealthHandler HealthHandler => _healthHandler;
    protected CharacterVFXHandler _vfxHandler;
    public CharacterVFXHandler VFXHandler => _vfxHandler;
    protected CharacterAnimationHandler _animationHandler;
    public CharacterAnimationHandler AnimationHandler => _animationHandler;
    public abstract void InitCharacter(AssetReference stats);
}