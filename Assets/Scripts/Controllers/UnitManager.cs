using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;
using System;

public class UnitManager : MonoBehaviour {
    public static UnitManager Instance { get; private set; }
    public static event Action<PlayerDrivenCharacter> OnPlayerSpawned;

    [System.Serializable]
    private struct Spawn {
        public AssetReference character;
        public Transform position;
    }

    [SerializeField] private Transform parent;
    [SerializeField]private Spawn[] initialPlayerSpawnList;
    [SerializeField]private Spawn[] initialNPCSpawnList;
    [SerializeField]private Spawn[] initialEnemySpawnList;

    private List<EnemyBase> _enemyList;
    public List<EnemyBase> EnemyList => _enemyList;
    private List<PlayerDrivenCharacter> _playerList;
    public List<PlayerDrivenCharacter> PlayerList => _playerList;
    private List<PlayerDrivenCharacter> _alivePlayers;
    public List<PlayerDrivenCharacter> AlivePlayers => _alivePlayers;
    private List<NPCBase> _npcList;
    public List<NPCBase> NPCList => _npcList;

    private void Awake() {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);

        _enemyList = new List<EnemyBase>();
        _playerList = new List<PlayerDrivenCharacter>();
        _npcList = new List<NPCBase>();
        _alivePlayers = new List<PlayerDrivenCharacter>();
    }

    private void OnEnable() {
        PlayerHealthHandler.OnPlayerDied += RemoveFromAlive;
        PlayerHealthHandler.OnResurrect += AddToAlive;
    }

    public void InitialSpawn() {
        SpawnPlayers();
        SpawnNPCs();
        SpawnEnemies();
    }

    private async void SpawnPlayers() {
        foreach(Spawn s in initialPlayerSpawnList) {
            PlayerDrivenCharacter player = await SpawnCharacter(s.character, s.position) as PlayerDrivenCharacter;
            _playerList.Add(player);
            AddToAlive(player);
        }
    }

    private void AddToAlive(PlayerDrivenCharacter player) {
        _alivePlayers.Add(player);
    }

    private void RemoveFromAlive(PlayerDrivenCharacter player) {
        _alivePlayers.Remove(player);
        GameController.Instance.CheckPlayers();
    }

    private async void SpawnNPCs() {
        foreach (Spawn s in initialNPCSpawnList) {
            NPCBase npc = await SpawnCharacter(s.character, s.position) as NPCBase;
            _npcList.Add(npc);
        }
    }

    private async void SpawnEnemies() {
        foreach (Spawn s in initialEnemySpawnList) {
            EnemyBase enemy = await SpawnCharacter(s.character, s.position) as EnemyBase;
            _enemyList.Add(enemy);
        }
    }

    public async Task<CharacterBase> SpawnCharacter(AssetReference reference, Transform position) {
        CharacterBaseStatsSO so = await reference.LoadAssetAsyncSafe<CharacterBaseStatsSO>();
        var op = so.SpawnPrefab.InstantiateAsync(position);

        CharacterBase character = null;
        op.Completed += (op) => {
            character = op.Result.GetComponent<CharacterBase>();
            character.transform.SetParent(parent);
            character.InitCharacter(so);
        };
        await op.Task;
        
        reference.ReleaseAsset();

        return character;
    }

    private void OnDisable() {
        PlayerHealthHandler.OnPlayerDied -= RemoveFromAlive;
        PlayerHealthHandler.OnResurrect -= AddToAlive;
    }
}



