using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerMovementController : MonoBehaviour, IMove
{
    private PlayerController playerController;
    private Rigidbody2D rb;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 direction)
    {
        rb.MovePosition(transform.position + (Vector3)direction.normalized * playerController.Stats.MoveSpeed);
        playerController.GraphicsController.SetMovementDirection(direction);
        AudioManager.Instance.PlaySound(AudioManager.Instance.GetSoundBoard<PlayerSoundBoard>().walk, playerController.transform.position, .2f);
    }
}
