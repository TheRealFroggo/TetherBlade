using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isTethered {get; set;}

    void Start()
    {
        isTethered = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otherObject = collision.rigidbody.gameObject;

        if (otherObject.tag == "Obstacle")
        {
            Die();
        }

        if (isTethered)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
