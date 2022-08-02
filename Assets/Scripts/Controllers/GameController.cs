using UnityEngine;

public class GameController : MonoBehaviour {
    public static GameController Instance { get; private set; }
    public enum GameState {
        Init,
        Win,
        Lose
    }
    public GameEvent OnWinEvent;
    public GameEvent OnLoseEvent;

    private GameState _gameState;
    [SerializeField] private IngameUIController _ingameUI;

    private void Awake() {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    private void Start() => SetGameState(GameState.Init);

    private void SetGameState(GameState state) {
        _gameState = state;

        switch (_gameState) {
            case GameState.Init: 
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

    public void Win() {
        Debug.LogWarning("!!!  Player WIN  !!!");
        SetGameState(GameState.Win);
    }

    protected virtual void OnWin() {
        Save();
        OnWinEvent?.Invoke();
    }

    public void Lose() {
        Debug.LogWarning("!!! PLAYER LOST !!!");
        SetGameState(GameState.Lose);
    }

    protected virtual void OnLose() {
        AudioManager.Instance.PlaySound(AudioManager.Instance.GetSoundBoard<GameActionsSoundBoard>().playerLost);
        OnLoseEvent?.Invoke();
    }

    public void CheckPlayers() {
        Debug.LogError("Check");
        if (UnitManager.Instance.AlivePlayers.Count <= 0)
            Lose();
    }

    private void Save() {
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
