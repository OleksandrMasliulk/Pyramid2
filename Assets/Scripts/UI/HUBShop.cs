using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUBShop : MonoBehaviour
{
    public Text goldText;

    private int gold;

    private void Awake()
    {
        PlayerData data = SaveLoad.Load<PlayerData>(SaveLoad.playerDataPath);
        if (data != null)
        {
            gold = data.gold;
        }
        else
        {
            gold = 0;
            data = new PlayerData(gold);
            SaveLoad.Save(data, SaveLoad.playerDataPath);
        }
    }

    private void Start()
    {
        UpdateGoldText(gold);
    }

    public void UpdateGoldText(int gold)
    {
        goldText.text = gold.ToString();
    }
}
