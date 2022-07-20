using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;

public class PlayerDrivenCharacter : CharacterBase
{
    public new PlayerCharacterStatsSO Stats => (PlayerCharacterStatsSO)_stats;
    [SerializeField] private InputMovementHandler _movementHandler;
    public InputMovementHandler MovementHandler => _movementHandler;
    [SerializeField] private PlayerInputHandler _inputHandler;
    [SerializeField] private PlayerInterractionHandler _interractionHandler;
    public PlayerInterractionHandler InterractionHandler => _interractionHandler;
    [SerializeField] private PlayerInventoryHandler _inventoryHandler;
    public PlayerInventoryHandler InventoryHandler => _inventoryHandler;
    [SerializeField] private PlayerHUDHandler _hudHandler;
    public PlayerHUDHandler HUDHandler => _hudHandler;
    public new PlayerHealthHandler HealthHandler => (PlayerHealthHandler)_healthHandler;
    [SerializeField] private PlayerSanityHandler _sanityHandler;
    public PlayerSanityHandler SanityHandler => _sanityHandler;
    public new PlayerAnimationHandler AnimationHandler => (PlayerAnimationHandler)_animationHandler;
    public new PlayerVFXHandler VFXHandler => (PlayerVFXHandler)_vfxHandler;

    private PlayerPhysicalStateMachine _physicalStateMachine;
    private PlayerSanityStateMachine _sanityStateMachine;

    [SerializeField] private Camera _ghostCamera;
    public Camera GhostCamera => _ghostCamera;

    public async override void InitCharacter(AssetReference stats)
    {
        _stats = await stats.LoadAssetAsyncSafe<CharacterBaseStatsSO>() as PlayerCharacterStatsSO;

        _movementHandler?.Init(_inputHandler, _stats.MovementSpeed);
        _inventoryHandler?.Init(_inputHandler, Stats.SlotCount);
        _interractionHandler?.Init(_inputHandler);
        _sanityHandler?.Init(Stats);

        _hudHandler.InitHUD(this, Stats);

        _physicalStateMachine = new PlayerPhysicalStateMachine(this);
        _sanityStateMachine = new PlayerSanityStateMachine(this);
    }
}
