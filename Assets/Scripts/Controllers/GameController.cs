using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public delegate void OnWinDelegate();
    public event OnWinDelegate OnWinEvent;
    public delegate void OnLoseDelegate();
    public event OnWinDelegate OnLoseEvent;

    public enum GameState
    {
        Init,
        SpawningCharacters,
        Win,
        Lose
    }
    private GameState _gameState;

    private AudioSource _levelTheme;

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
                PlayLevelTheme();
                _alivePlayersList = new List<PlayerDrivenCharacter>();
                //PlayerHealthController.OnPlayerDied += RemovePlayerFromAlive;
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

    public void PlayLevelTheme()
    {
        //if (_levelTheme == null)
        //{
        //    _levelTheme = AudioManager.PlaySound(AudioManager.Sound.LevelTheme, true);
        //}
        //else
        //{
        //    _levelTheme.UnPause();
        //}
    }

    public void PauseLevelTheme()
    {
        //_levelTheme.Pause();
    }
}
