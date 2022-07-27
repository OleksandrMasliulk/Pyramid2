using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUBController : MonoBehaviour
{
    [SerializeField] private HUBMapManager _mapManager;

    private List<PlayerDrivenCharacter> _playersInHUB;

    private void Awake()
    {
        _playersInHUB = new List<PlayerDrivenCharacter>();
        UnitManager.OnPlayerSpawned += AddPlayer;
    }

    private void Start()
    {
        UnitManager.Instance.InitialSpawn();
    }

    private void AddPlayer(PlayerDrivenCharacter player)
    {
        _playersInHUB.Add(player);
    }

    private void RemovePlayer(PlayerDrivenCharacter player)
    {
        _playersInHUB.Remove(player);
    }

    public void StartGame()
    {
        LevelLoader.Instance.LoadLevel(_mapManager.SelectedMap);
    }

    public void MainMenu()
    {
        LevelLoader.Instance.MainMenu();
    }
}
