using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 Direction { get; set; }
    public float ProjectileSpeed;

    public float Lifetime;

    public bool ShouldDestroyOnCollision = false;

    private Rigidbody2D Rigidbody;

    virtual protected void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        SetInitialVelocity();
    }

    virtual protected void FixedUpdate()
    {
        TickLifetime();
        UpdateRotation();
    }

    protected void SetInitialVelocity()
    {
        Vector3 Velocity = Direction * ProjectileSpeed;

        Rigidbody.velocity = Velocity;
    }

    protected void UpdateRotation()
    {
        Rigidbody.angularVelocity = 0;
        Vector2 direction = Rigidbody.velocity.normalized;
        float angle = -1 * (Mathf.Atan2(direction.x, direction.y) * 180 / Mathf.PI) - 90;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    protected void TickLifetime()
    {
        Lifetime -= Time.fixedDeltaTime;

        if (Lifetime <= 0)
        {
            Die();
        }
    }

    virtual protected void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ShouldDestroyOnCollision)
        {
            Destroy(gameObject);
        }
    }
}