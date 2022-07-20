using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;

public class Mummy : EnemyBase
{
    public new MummyStatsSO Stats => (MummyStatsSO)_stats;
    public new MummyGraphicsController AnimationHandler => (MummyGraphicsController)_animationHandler;
    [SerializeField] private ISeeker<PlayerDrivenCharacter> _playerSeeker;
    public ISeeker<PlayerDrivenCharacter> PlayerSeeker => _playerSeeker;

    private MummyBehavoiuStateMachine _behavoiurStateMachine;

    public override async void InitCharacter(AssetReference stats)
    {
        _stats = await stats.LoadAssetAsyncSafe<CharacterBaseStatsSO>() as MummyStatsSO;

        _playerSeeker = GetComponent<ISeeker<PlayerDrivenCharacter>>();
        _behavoiurStateMachine = new MummyBehavoiuStateMachine(this);
    }

    private void Update()
    {
        _behavoiurStateMachine.Tick();
    }
}