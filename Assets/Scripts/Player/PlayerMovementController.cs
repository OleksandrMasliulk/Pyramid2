using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerMovementController : MonoBehaviour
{
    private PlayerController playerController;
    private Rigidbody2D rb;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (playerController.GetPlayerParameters().isAlive)
        {
            Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (dir.magnitude > 0f)
            {
                Move(dir);
                playerController.GetPlayerGraphicsController().SetMovementState(dir);
            }
            else
            {
                playerController.GetPlayerGraphicsController().SetIdle();
            }
        }
    }

    private void Move(Vector2 direction)
    {
        rb.MovePosition(transform.position + (Vector3)direction * playerController.GetPlayerParameters().movementSpeed);
    }
}
