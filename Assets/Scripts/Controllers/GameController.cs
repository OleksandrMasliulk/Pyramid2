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

    private AudioSource levelTheme;

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
        AudioManager.Init();
    }

    private void Start()
    {
        PlayLevelTheme();
    }

    public virtual void Win()
    {
        Debug.LogWarning("!!!  Player WIN  !!!");

        Save();

        OnWin?.Invoke();
    }

    public virtual void Lose()
    {
        Debug.LogWarning("!!! PLAYER LOST !!!");
        AudioManager.PlaySound(AudioManager.Sound.PlayerDieFX);

        //Save();

        OnLose?.Invoke();
    }

    public int CalculateGold()
    {
        int gold = 0;

        for (int i = 0; i < 4; i++)
        {
            Treasure treasure = PlayerController.Instance.GetPlayerInventoryController().GetItemFromSlot(i) as Treasure;
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

    public void PlayLevelTheme()
    {
        if (levelTheme == null)
        {
            levelTheme = AudioManager.PlaySound(AudioManager.Sound.LevelTheme, true);
        }
        else
        {
            levelTheme.UnPause();
        }
    }

    public void PauseLevelTheme()
    {
        levelTheme.Pause();
    }
}
