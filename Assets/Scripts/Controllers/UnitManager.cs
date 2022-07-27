using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;
using System;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance { get; private set; }

    [System.Serializable]
    private struct Spawn
    {
        public AssetReference character;
        public Transform position;
    }

    public static event Action<PlayerDrivenCharacter> OnPlayerSpawned;

    [SerializeField] private Transform parent;

    [SerializeField]private Spawn[] initialPlayerSpawnList;
    [SerializeField]private Spawn[] initialNPCSpawnList;
    [SerializeField]private Spawn[] initialEnemySpawnList;

    private List<EnemyBase> _enemyList;
    public List<EnemyBase> EnemyList => _enemyList;
    private List<PlayerDrivenCharacter> _playerList;
    public List<PlayerDrivenCharacter> PlayerList => _playerList;
    private List<NPCBase> _npcList;
    public List<NPCBase> NPCList => _npcList;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        _enemyList = new List<EnemyBase>();
        _playerList = new List<PlayerDrivenCharacter>();
        _npcList = new List<NPCBase>();
    }

    public void InitialSpawn()
    {
        SpawnPlayers();
        SpawnNPCs();
        SpawnEnemies();
    }

    private async void SpawnPlayers()
    {
        foreach(Spawn s in initialPlayerSpawnList)
        {
            CharacterBase player = await SpawnCharacter(s.character, s.position);
            _playerList.Add((PlayerDrivenCharacter)player);
            OnPlayerSpawned?.Invoke((PlayerDrivenCharacter)player);
        }
    }

    private async void SpawnNPCs()
    {
        foreach (Spawn s in initialNPCSpawnList)
        {
            CharacterBase npc = await SpawnCharacter(s.character, s.position);
            _npcList.Add((NPCBase)npc);
        }
    }

    private async void SpawnEnemies()
    {
        foreach (Spawn s in initialEnemySpawnList)
        {
            CharacterBase enemy = await SpawnCharacter(s.character, s.position);
            _enemyList.Add((EnemyBase)enemy);
        }
    }

    public async Task<CharacterBase> SpawnCharacter(AssetReference reference, Transform position)
    {
        CharacterBaseStatsSO so = await reference.LoadAssetAsyncSafe<CharacterBaseStatsSO>();
        var op = so.SpawnPrefab.InstantiateAsync(position);
        CharacterBase character = null;
        op.Completed += (op) =>
        {
            character = op.Result.GetComponent<CharacterBase>();
            character.transform.SetParent(parent);
            character.InitCharacter(reference);
        };

        await op.Task;
        reference.ReleaseAsset();
        return character;
    }
}



