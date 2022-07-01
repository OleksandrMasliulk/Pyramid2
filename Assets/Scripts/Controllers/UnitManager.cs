using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance { get; private set; }

    [System.Serializable]
    private struct Spawn
    {
        public CharacterBaseSO character;
        public Transform position;
    }

    [SerializeField] private Transform parent;

    [SerializeField]private Spawn[] initialPlayerSpawnList;
    [SerializeField]private Spawn[] initialNPCSpawnList;
    [SerializeField]private Spawn[] initialEnemySpawnList;

    private List<EnemyBase> _enemyList;
    public List<EnemyBase> EnemyList => _enemyList;
    private List<PlayerController> _playerList;
    public List<PlayerController> PlayerList => _playerList;
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
        _playerList = new List<PlayerController>();
        _npcList = new List<NPCBase>();
    }

    public void InitialSpawn()
    {
        SpawnPlayers();
        SpawnNPCs();
        SpawnEnemies();
    }

    private void SpawnPlayers()
    {
        foreach(Spawn s in initialPlayerSpawnList)
        {
            PlayerController player = (PlayerController)SpawnCharacter(s.character, s.position);
            _playerList.Add(player);
            GameController.Instance.AlivePlayersList.Add(player);
        }
    }

    private void SpawnNPCs()
    {
        foreach (Spawn s in initialNPCSpawnList)
        {
            NPCBase npc = (NPCBase)SpawnCharacter(s.character, s.position);
            _npcList.Add(npc);
        }
    }

    private void SpawnEnemies()
    {
        foreach (Spawn s in initialEnemySpawnList)
        {
            EnemyBase enemy = (EnemyBase)SpawnCharacter(s.character, s.position);
            _enemyList.Add(enemy);
        }
    }

    public CharacterBase SpawnCharacter(CharacterBaseSO so, Transform position)
    {
        CharacterBase character = Instantiate(so.prefab, position.position, Quaternion.identity);
        character.transform.SetParent(parent);
        character.InitCharacter(so.Stats);

        return character;
    }
}



