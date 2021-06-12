using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public GameObject Player;
    public float MovementSpeed;

    private Rigidbody2D Rigidbody;
    private SpriteRenderer SpriteRenderer;

    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Rigidbody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        Vector3 pos = transform.position;
        Vector3 playerPos = Player.transform.position;

        Vector3 direction = playerPos - pos;
        direction.Normalize();
        Rigidbody.velocity = direction * MovementSpeed;

        if (direction.x >= 0)
            SpriteRenderer.flipX = false;
        else
            SpriteRenderer.flipX = true;
    }
}
