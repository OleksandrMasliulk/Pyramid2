using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerParameters parameters;
    private Rigidbody2D rb;

    [SerializeField] private float wallCheckRadius;
    [SerializeField] private LayerMask wallCheckLayer;

    private void Start()
    {
        parameters = GetComponent<PlayerParameters>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (parameters.isAlive)
        {
            if (Input.anyKey)
            {
                Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                Move(dir);
            }
        }
    }

    private void Move(Vector2 direction)
    {
        rb.MovePosition(transform.position + (Vector3)direction * parameters.movementSpeed);
    }
}
