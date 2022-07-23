using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class PlayerDrivenCharacter : CharacterBase
{
    public new PlayerCharacterStatsSO Stats => (PlayerCharacterStatsSO)_stats;
    private ICanMove _movementHandler;
    public InputMovementHandler MovementHandler => (InputMovementHandler)_movementHandler;
    private PlayerInputHandler _inputHandler;
    private PlayerInterractionHandler _interractionHandler;
    public PlayerInterractionHandler InterractionHandler => _interractionHandler;
    private PlayerInventoryHandler _inventoryHandler;
    public PlayerInventoryHandler InventoryHandler => _inventoryHandler;
    private PlayerHUDHandler _hudHandler;
    public PlayerHUDHandler HUDHandler => _hudHandler;
    public new PlayerHealthHandler HealthHandler => (PlayerHealthHandler)_healthHandler;
    private IHaveSanity _sanityHandler;
    public PlayerSanityHandler SanityHandler => (PlayerSanityHandler)_sanityHandler;
    public new PlayerAnimationHandler AnimationHandler => (PlayerAnimationHandler)_animationHandler;
    public new PlayerVFXHandler VFXHandler => (PlayerVFXHandler)_vfxHandler;

    private PlayerPhysicalStateMachine _physicalStateMachine;
    private PlayerSanityStateMachine _sanityStateMachine;

    [SerializeField] private PlayerCameraHandler _cameraHandler;
    public PlayerCameraHandler CameraHandler => _cameraHandler;
    [SerializeField] private PlayerSelector _selector;
    public PlayerSelector Selector => _selector;

    public async override void InitCharacter(AssetReference stats)
    {
        _stats = await stats.LoadAssetAsyncSafe<CharacterBaseStatsSO>() as PlayerCharacterStatsSO;

        _movementHandler = GetComponent<ICanMove>();
        _healthHandler = GetComponent<CharacterHealthHandler>();
        _inputHandler = GetComponent<PlayerInputHandler>();
        _interractionHandler = GetComponent<PlayerInterractionHandler>();
        _inventoryHandler = GetComponent<PlayerInventoryHandler>();
        _animationHandler = GetComponent<CharacterAnimationHandler>();
        _vfxHandler = GetComponent<CharacterVFXHandler>();
        _sanityHandler = GetComponent<IHaveSanity>();
        _hudHandler = GetComponent<PlayerHUDHandler>();
        _selector = GetComponent<PlayerSelector>();

        MovementHandler?.Init(_stats.MovementSpeed);
        InventoryHandler?.Init(Stats.SlotCount);
        SanityHandler?.Init(Stats);

        HUDHandler.InitHUD(this, Stats);

        _physicalStateMachine = new PlayerPhysicalStateMachine(this);
        _sanityStateMachine = new PlayerSanityStateMachine(this);
    }
}
