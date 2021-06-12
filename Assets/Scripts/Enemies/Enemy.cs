using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isTethered {get; set;}
    public GameObject BloodSplash;

    private Rigidbody2D Rigidbody;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        isTethered = false;
    }

    void FixedUpdate()
    {
        if (isTethered)
            Rigidbody.bodyType = RigidbodyType2D.Dynamic;
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
        GameObject blood = Instantiate(BloodSplash);
        blood.transform.position = transform.position;

        int randDegree = Random.Range(0, 359);
        blood.transform.rotation = Quaternion.Euler(0, 0, randDegree);

        Destroy(gameObject);
    }
}
