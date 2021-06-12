using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetherChildProjectile : MonoBehaviour
{
    public Tether Tether;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!Tether.Object1)
        {
            Tether.Object1 = collider.gameObject;
        }
        else
        {
            Tether.Object2 = collider.gameObject;
        }
        Destroy(gameObject);
    }
}