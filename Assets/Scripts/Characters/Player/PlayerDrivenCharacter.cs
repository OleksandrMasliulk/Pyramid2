using UnityEngine;
using UnityEngine.AddressableAssets;

public class PlayerDrivenCharacter : CharacterBase {
    public new PlayerCharacterStatsSO Stats => (PlayerCharacterStatsSO)_stats;
    private ICanMove _movementHandler;
    public InputMovementHandler MovementHandler => (InputMovementHandler)_movementHandler;
    private PlayerInputController _inputController;
    public PlayerInputController InputController => _inputController;
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
    private PlayerCoverHandler _coverHandler;
    public PlayerCoverHandler CoverHandler => _coverHandler;
    [SerializeField] private AssetReference _soundboardReference;
    public PlayerSoundBoardSO LoadedSoundboard {get; private set;}

    [SerializeField] private PlayerCameraHandler _cameraHandler;
    public PlayerCameraHandler CameraHandler => _cameraHandler;
    private PlayerSelector _selector;
    public PlayerSelector Selector => _selector;

    private async void Awake() {
        _movementHandler = GetComponent<ICanMove>();
        _healthHandler = GetComponent<CharacterHealthHandler>();
        _inputController = GetComponent<PlayerInputController>();
        _interractionHandler = GetComponent<PlayerInterractionHandler>();
        _inventoryHandler = GetComponent<PlayerInventoryHandler>();
        _animationHandler = GetComponent<CharacterAnimationHandler>();
        _vfxHandler = GetComponent<CharacterVFXHandler>();
        _sanityHandler = GetComponent<IHaveSanity>();
        _hudHandler = GetComponent<PlayerHUDHandler>();
        _selector = GetComponent<PlayerSelector>();
        _coverHandler = GetComponent<PlayerCoverHandler>();
        LoadedSoundboard = await _soundboardReference.LoadAssetAsyncSafe<PlayerSoundBoardSO>();
    }

    public override void InitCharacter(CharacterBaseStatsSO stats) {
        _stats = stats;

        MovementHandler?.Init(Stats.MovementSpeed);
        InventoryHandler?.Init(Stats.SlotCount);
        SanityHandler?.Init(Stats);
        HUDHandler.InitHUD(this);
    }

    private void OnDestroy() {
        LoadedSoundboard.Dispose();
        _soundboardReference.ReleaseAssetSafe();
    }
}
