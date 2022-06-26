using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerHealthController : MonoBehaviour
{
    public delegate void OnPlayerDiedDelegate(PlayerController player);
    public static event OnPlayerDiedDelegate OnPlayerDied;

    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void Die()
    {
        playerController.SetState(playerController.deadState);

        OnPlayerDied?.Invoke(playerController);
    }
}
