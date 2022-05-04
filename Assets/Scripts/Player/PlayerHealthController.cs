using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerHealthController : MonoBehaviour, IDamageable
{
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

        GameController.Instance.Lose();
    }
}
