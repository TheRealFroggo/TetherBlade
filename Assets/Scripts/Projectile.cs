using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 Direction { get; set; }
    public float ProjectileSpeed;

    public float Lifetime;

    void Update()
    {
        TickLifetime();
    }

    void FixedUpdate()
    {
        ProjectileMovement();
    }

    protected void ProjectileMovement()
    {
        Vector3 Velocity = Direction * ProjectileSpeed;

        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Velocity;
    }

    protected void TickLifetime()
    {
        Lifetime -= Time.deltaTime;

        if (Lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
