using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetherGunProjectile : Projectile
{
    public Vector2 MousePos;

    void Update()
    {
        CheckPosition();
        TickLifetime();
    }

    void CheckPosition()
    {
        Vector3 pos = transform.position;

        //If true, that means the position of bullet is within 1 unit of MousePosition
        if (Mathf.Abs(pos.x - MousePos.x) < 1.0f &&
            Mathf.Abs(pos.y - MousePos.y) < 1)
        {
            Destroy(gameObject);
        }
    }
}
