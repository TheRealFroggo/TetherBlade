using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public float MovementSpeed;

    private Rigidbody2D Rigidbody;
    private SpriteRenderer SpriteRenderer;
    private Enemy Enemy;

    private GameObject Player;

    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Rigidbody = GetComponent<Rigidbody2D>();
        Enemy = GetComponent<Enemy>();
        Player = Enemy.Player;
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
