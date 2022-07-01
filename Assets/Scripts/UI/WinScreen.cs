using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private Text collectedGoldText;

    private void OnEnable()
    {
        collectedGoldText.text = GameController.Instance.AlivePlayersList[0].InventoryController.CalculateInventoryValue().ToString();
    }
}
