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
            TetherEnemy(Tether.Object1);
        }
        else
        {
            Tether.Object2 = collider.gameObject;
            TetherEnemy(Tether.Object2);
        }
        Destroy(gameObject);
    }

    void TetherEnemy(GameObject obj)
    {
        Enemy enemy = obj.gameObject.GetComponent<Enemy>();
        if (enemy)
            enemy.isTethered = true;
    }
}