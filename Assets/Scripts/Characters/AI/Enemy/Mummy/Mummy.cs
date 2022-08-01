using UnityEngine;
using UnityEngine.AddressableAssets;

public class Mummy : EnemyBase {
    public new MummyStatsSO Stats => (MummyStatsSO)_stats;
    public new MummyAnimationHandler AnimationHandler => (MummyAnimationHandler)_animationHandler;
    public new AIPathfindingMovement MovementHandler => (AIPathfindingMovement)_movementHandler;

    [SerializeField] private ISeeker<PlayerDrivenCharacter> _playerSeeker;
    public ISeeker<PlayerDrivenCharacter> PlayerSeeker => _playerSeeker;
    private MummyBehavoiuStateMachine _behavoiurStateMachine;
    private MummyPhysicalStateMachine _physicalStateMachine;

    public override async void InitCharacter(AssetReference stats) {
        _stats = await stats.LoadAssetAsyncSafe<CharacterBaseStatsSO>() as MummyStatsSO;

        _movementHandler = GetComponent<IPathfindingMovement>();
        _animationHandler = GetComponent<CharacterAnimationHandler>();
        _vfxHandler = GetComponent<CharacterVFXHandler>();
        _healthHandler = GetComponent<CharacterHealthHandler>();

        _playerSeeker = GetComponentInChildren<ISeeker<PlayerDrivenCharacter>>();
        _behavoiurStateMachine = new MummyBehavoiuStateMachine(this);
        _physicalStateMachine = new MummyPhysicalStateMachine(this);
    }

    private void Update() => _behavoiurStateMachine.Tick();
}