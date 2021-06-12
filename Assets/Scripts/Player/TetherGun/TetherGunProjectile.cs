using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetherGunProjectile : Projectile
{
    public float CloseEnough;
    public Tether TetherPrefab;
    public Vector2 MousePos;

    override protected void FixedUpdate()
    {
        base.FixedUpdate();
        CheckPosition();
    }

    void CheckPosition()
    {
        Vector3 pos = transform.position;

        //If true, that means the position of bullet is within CloseEnough unit of MousePosition
        if (Mathf.Abs(pos.x - MousePos.x) < CloseEnough &&
            Mathf.Abs(pos.y - MousePos.y) < CloseEnough)
        {
            Die();
        }
    }

    override protected void Die()
    {
        SpawnChildren();

        Destroy(gameObject);
    }

    void SpawnChildren()
    {
        Tether tether = Instantiate(TetherPrefab);

        tether.transform.position = transform.position;
        tether.transform.rotation = transform.rotation;
        tether.transform.Rotate(0, 0, 90);

        tether.TetherEndLeft.Direction = -tether.transform.right;
        tether.TetherEndRight.Direction = tether.transform.right;
    }
}
