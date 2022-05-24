using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerHealthController : MonoBehaviour, IDamageable
{
    public delegate void OnPlayerDiedDelegate();
    public event OnPlayerDiedDelegate OnPlayerDied;

    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void TakeDamage(int damage)
    {
        Die();
    }

    private void Die()
    {
        playerController.SetState(playerController.deadState);
        AudioManager.PlaySound(AudioManager.Sound.PlayerDie);

        OnPlayerDied?.Invoke();

        if (GameController.Instance != null)
            GameController.Instance.Lose();
    }
}
