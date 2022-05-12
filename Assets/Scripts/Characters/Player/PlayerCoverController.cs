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
        if (playerController.GetPlayerSanityController().GetSanity() <= 25)
        {
            Debug.Log("You can't cover with low sanity");
            return;
        }

        playerController.SetState(playerController.coveredState);

        playerController.GetPlayerParameters().SetIsCovered(true);

        playerController.SetPlayerLayer(10);
        col.isTrigger = true;
        playerController.GetPlayerGraphicsController().DisableRenderer();
        playerController.GetPlayerMovementController().enabled = false;

        transform.position = coverPos;

        OnPlayerCovered?.Invoke();
    }

    public void Uncover(Vector3 respawnPos)
    {
        playerController.SetState(playerController.aliveState);

        playerController.GetPlayerParameters().SetIsCovered(false);

        playerController.SetPlayerLayer(6);
        col.isTrigger = false;
        playerController.GetPlayerGraphicsController().EnableRenderer();
        playerController.GetPlayerMovementController().enabled = true;

        transform.position = respawnPos;
    }
}
