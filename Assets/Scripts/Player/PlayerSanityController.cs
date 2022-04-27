using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerSanityController : MonoBehaviour
{
    private PlayerController playerController;

    public delegate void OnLowSanityDelegate(PlayerController player);
    public event OnLowSanityDelegate OnLowSanity;

    private int currentSanity;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        currentSanity = playerController.GetPlayerParameters().maxSanity;
        UpdateSanity(currentSanity);
    }

    public void UpdateSanity(int value)
    {
        currentSanity += value;

        if (currentSanity < 0)
        {
            currentSanity = 0;
        }
        if (currentSanity > 100)
        {
            currentSanity = 100;
        }

        if (currentSanity <= 25)
        {
            OnLowSanity?.Invoke(this.playerController);
        }

        playerController.GetPlayerHUDContorller().UpdateSanitySlider(currentSanity);
    }

    public int GetSanity()
    {
        return currentSanity;
    }
}
