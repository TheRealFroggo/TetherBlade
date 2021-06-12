using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isTethered { get; set; }
    public GameObject BloodSplash;
    public GameObject BloodParticle;

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

        if (isTethered)
        {
            if (otherObject.tag == "Obstacle" || otherObject.tag == "Enemy" || otherObject.tag == "Wall")
            {
                Die();
            }
        }
    }

    void Die()
    {
        GameObject splash = Instantiate(BloodSplash);
        splash.transform.position = transform.position;

        GameObject blood = Instantiate(BloodParticle);
        blood.transform.position = transform.position;
        int randDegree = Random.Range(0, 359);
        blood.transform.rotation = Quaternion.Euler(0, 0, randDegree);

        Destroy(gameObject);
    }
}
