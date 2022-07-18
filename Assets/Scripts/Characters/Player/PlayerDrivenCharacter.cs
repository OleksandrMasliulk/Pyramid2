using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;

public class PlayerDrivenCharacter : CharacterBase
{
    public AssetReference _stats;

    [SerializeField]private InputMovementHandler _movementHandler;
    public InputMovementHandler MovementHandler => _movementHandler;
    [SerializeField]private PlayerInputHandler _inputHandler;
    //public RPlayerInputHandler InputHandler => _inputHandler;
    [SerializeField]private PlayerInterractionHandler _interractionHandler;
    public PlayerInterractionHandler InterractionHandler => _interractionHandler;
    [SerializeField] private PlayerInventoryHandler _inventoryHandler;
    public PlayerInventoryHandler InventoryHandler => _inventoryHandler;
    [SerializeField] private PlayerHUDHandler _hudHandler;
    public PlayerHUDHandler HUDHandler => _hudHandler;
    [SerializeField] private PlayerSanityHandler _sanityHandler;
    public PlayerSanityHandler SanityHandler => _sanityHandler;
    public new PlayerAnimationHandler AnimationHandler => (PlayerAnimationHandler)_animationHandler;
    public new PlayerVFXHandler VFXHandler => (PlayerVFXHandler)_vfxHandler;
    //FOR TEST ONLY
    private void Awake()
    {
        InitCharacter(_stats);
    }

    public async override void InitCharacter(AssetReference stats)
    {
        PlayerCharacterStatsSO playerStats = await stats.LoadAssetAsyncSafe<PlayerCharacterStatsSO>();

        _movementHandler?.Init(_inputHandler, playerStats.MovementSpeed);
        _inventoryHandler?.Init(_inputHandler, playerStats.SlotCount);
        _interractionHandler?.Init(_inputHandler);
        _sanityHandler?.Init(playerStats);

        _hudHandler.InitHUD(this, playerStats);
    }
}
