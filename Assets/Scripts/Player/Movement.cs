using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float MovementSpeed;
    [SerializeField]
    GameObject TetherGun;

    [SerializeField]
    GameObject BloodSplash;
    [SerializeField]
    GameObject BloodParticle;
    [SerializeField]
    GameManager GameManager;

    Rigidbody2D rigidBody;
    SpriteRenderer spriteRenderer;

    private Vector2 MovementVector;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        DoMovement();
    }

    void DoMovement()
    {
        MovementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rigidBody.velocity = MovementVector * MovementSpeed;
        spriteRenderer.flipX = TetherGun.GetComponent<TetherGunRotation>().isGunFlipped;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otherobject = collision.rigidbody.gameObject;

        if (otherobject.tag == "Enemy" || otherobject.tag == "Obstacle")
            Die();
    }

    void Die()
    {
        MovementVector = Vector2.zero;
        rigidBody.velocity = Vector2.zero;
        rigidBody.bodyType = RigidbodyType2D.Static;

        SpawnBlood();

        enabled = false;
        spriteRenderer.enabled = false;
        TetherGun.GetComponent<TetherGunRotation>().enabled = false;
        TetherGun.GetComponent<TetherGunShooting>().enabled = false;
        TetherGun.GetComponent<SpriteRenderer>().enabled = false;

        GameManager.PlayerDied();
    }

    void SpawnBlood()
    {
        GameObject splash = Instantiate(BloodSplash);
        splash.transform.position = transform.position;

        GameObject blood = Instantiate(BloodParticle);
        blood.transform.position = transform.position;
        int randDegree = Random.Range(0, 359);
        blood.transform.rotation = Quaternion.Euler(0, 0, randDegree);
    }

    public void Restart()
    {
        transform.position = Vector3.zero;
        rigidBody.bodyType = RigidbodyType2D.Dynamic;

        enabled = true;
        spriteRenderer.enabled = true;
        TetherGun.GetComponent<TetherGunRotation>().enabled = true;
        TetherGun.GetComponent<TetherGunShooting>().enabled = true;
        TetherGun.GetComponent<SpriteRenderer>().enabled = true;
    }
}
