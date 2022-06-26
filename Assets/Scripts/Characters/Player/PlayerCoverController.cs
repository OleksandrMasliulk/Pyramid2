using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerCoverController : MonoBehaviour
{
    public delegate void OnPlayerCoveredDelegate();
    public event OnPlayerCoveredDelegate OnPlayerCovered;

    private PlayerController playerController;

    private Rigidbody2D rb;
    private Collider2D col;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    public void Cover(Vector3 coverPos)
    {
        if (playerController.SanityController.CurrentSanity <= 25)
        {
            Debug.Log("You can't cover with low sanity");
            return;
        }

        playerController.SetState(playerController.coveredState);

        col.isTrigger = true;
        transform.position = coverPos;

        OnPlayerCovered?.Invoke();
    }

    public void Uncover(Vector3 respawnPos)
    {
        playerController.SetState(playerController.aliveState);

        playerController.Stats.SetCovered(false);

        col.isTrigger = false;
        transform.position = respawnPos;
    }
}
