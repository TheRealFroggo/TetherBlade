﻿using System.Collections;
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

    protected void UpdateRotation()
    {
        Rigidbody.angularVelocity = 0;
        Vector2 direction = Rigidbody.velocity.normalized;
        float angle = -1 * (Mathf.Atan2(direction.x, direction.y) * 180 / Mathf.PI) - 90;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        Debug.Log(angle);
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