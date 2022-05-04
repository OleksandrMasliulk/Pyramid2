using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public delegate void OnWinDelegate();
    public event OnWinDelegate OnWin;
    public delegate void OnLoseDelegate();
    public event OnWinDelegate OnLose;

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

    public void Win()
    {
        Debug.LogWarning("!!!  Player WIN  !!!");

        Save();

        OnWin?.Invoke();
    }

    public void Lose()
    {
        Debug.LogWarning("!!! PLAYER LOST !!!");

        Save();

        OnLose?.Invoke();
    }

    public int CalculateGold()
    {
        int gold = 0;

        for (int i = 0; i < 4; i++)
        {
            PickableTreasure treasure = PlayerController.Instance.GetPlayerInventoryController().GetItemFromSlot(i) as PickableTreasure;
            if (treasure != null)
            {
                gold += treasure.value;
            }
        }

        return gold;
    }

    private void Save()
    {
        PlayerData data = SaveLoad.Load();
        if (data != null)
        {
            data.gold += CalculateGold();
        }
        else
        {
            data = new PlayerData(CalculateGold());
        }
        SaveLoad.Save(data);
    }
}
