using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public event Action OnWinEvent;
    public event Action OnLoseEvent;

    public enum GameState
    {
        Init,
        SpawningCharacters,
        Win,
        Lose
    }
    private GameState _gameState;

    private List<PlayerDrivenCharacter> _alivePlayersList;
    public List<PlayerDrivenCharacter> AlivePlayersList => _alivePlayersList;

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

        _alivePlayersList = new List<PlayerDrivenCharacter>();
    }

    private void Start()
    {
        SetGameState(GameState.Init);
    }

    private void SetGameState(GameState state)
    {
        _gameState = state;

        switch (_gameState)
        {
            case GameState.Init: 
                SetGameState(GameState.SpawningCharacters);
                break;

            case GameState.SpawningCharacters:
                UnitManager.Instance.InitialSpawn();
                break;

            case GameState.Win:
                OnWin();
                break;

            case GameState.Lose:
                OnLose();
                break;
        }
    }

    public void Win()
    {
        Debug.LogWarning("!!!  Player WIN  !!!");
        SetGameState(GameState.Win);
    }

    protected virtual void OnWin()
    {
        Save();
        OnWinEvent?.Invoke();
    }

    public void Lose()
    {
        Debug.LogWarning("!!! PLAYER LOST !!!");
        SetGameState(GameState.Lose);
    }


    protected virtual void OnLose()
    {
        AudioManager.Instance.PlaySound(AudioManager.Instance.GetSoundBoard<GameActionsSoundBoard>().playerLost);
        OnLoseEvent?.Invoke();
    }

    public void AddPlayerToList(PlayerDrivenCharacter player)
    {
        _alivePlayersList.Add(player);
        player.HealthHandler.OnCharacterDie += (player) => RemovePlayerFromAlive((PlayerDrivenCharacter)player);
    }


    private void RemovePlayerFromAlive(PlayerDrivenCharacter player)
    {
        _alivePlayersList.Remove(player);
        CheckPlayers();
    }

    private void CheckPlayers()
    {
        if (_alivePlayersList.Count <= 0)
        {
            Lose();
        }
    }

    private void OnEnable()
    {
        UnitManager.OnPlayerSpawned += AddPlayerToList;
    }

    private void OnDisable()
    {
        UnitManager.OnPlayerSpawned -= AddPlayerToList;
    }

    private void Save()
    {
        //PlayerData data = SaveLoad.Load<PlayerData>(SaveLoad.playerDataPath);
        //if (data != null)
        //{
        //    data.gold += _alivePlayersList[0].InventoryController.CalculateInventoryValue();
        //}
        //else
        //{
        //    data = new PlayerData(_alivePlayersList[0].InventoryController.CalculateInventoryValue());
        //}
        //SaveLoad.Save(data, SaveLoad.playerDataPath);
    }
}
