using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 Direction { get; set; }
    public float ProjectileSpeed;

    public float Lifetime;

    private Rigidbody2D Rigidbody;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        SetInitialVelocity();
    }

    void Update()
    {
        TickLifetime();
        UpdateRotation();
    }

    protected void SetInitialVelocity()
    {
        Vector3 Velocity = Direction * ProjectileSpeed;

        Rigidbody.velocity = Velocity;
    }

    void UpdateRotation()
    {
        Vector2 direction = Rigidbody.velocity.normalized;
        float angle = Mathf.Atan2(direction.x, direction.y) * 180 / Mathf.PI;
        Debug.Log(angle);
        transform.rotation = Quaternion.Euler(0, 0, angle);
        //transform.rotation = Quaternion.LookRotation(direction);
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