using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerParameters parameters;
    private PlayerGraphicsController graphics;
    private Rigidbody2D rb;

    [SerializeField] private float wallCheckRadius;
    [SerializeField] private LayerMask wallCheckLayer;

    private void Start()
    {
        parameters = GetComponent<PlayerParameters>();
        graphics = GetComponent<PlayerGraphicsController>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (parameters.isAlive)
        {
            Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (dir.magnitude > 0f)
            {
                Move(dir);
                graphics.SetMovementState(dir);
            }
            else
            {
                graphics.SetIdle();
            }
        }
    }

    private void Move(Vector2 direction)
    {
        rb.MovePosition(transform.position + (Vector3)direction * parameters.movementSpeed);
    }
}
