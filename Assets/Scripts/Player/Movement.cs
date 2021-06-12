using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float MovementSpeed;
    [SerializeField]
    GameObject TetherGun;

    Rigidbody2D rigidBody;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        DoMovement();
    }

    void DoMovement()
    {
        Vector2 movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rigidBody.velocity = movementVector * MovementSpeed;
        spriteRenderer.flipX = TetherGun.GetComponent<TetherGunRotation>().isGunFlipped;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otherobject = collision.rigidbody.gameObject;

        if (otherobject.tag == "Enemy")
            Die();
    }

    void Die()
    {
        rigidBody.velocity = Vector2.zero;
        rigidBody.bodyType = RigidbodyType2D.Static;
        this.enabled = false;
    }
}
