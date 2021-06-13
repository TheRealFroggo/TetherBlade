using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    public float MovementSpeed;
    public float StrafeDistance;
    [Tooltip("How many volleys fired per second")]
    public float FireRate;
    private float FireRateTimer;
    [Tooltip("How many shots in one volley")]
    public float ShotsPerVolley;
    [Tooltip("How many degrees between each shot in the volley")]
    public float SeperationDegrees;

    public GameObject Projectile;

    private GameObject Player;
    private Rigidbody2D Rigidbody;
    private SpriteRenderer SpriteRenderer;

    void Start()
    {
        FireRateTimer = FireRate;
        Player = GetComponent<Enemy>().Player;
        Rigidbody = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        DoMovement();
        TickFireRate();
    }

    void DoMovement()
    {
        Vector3 pos = transform.position;
        Vector3 playerPos = Player.transform.position;

        Vector3 direction = playerPos - pos;

        if (direction.sqrMagnitude >= StrafeDistance)
        {
            direction.Normalize();
            Rigidbody.velocity = direction * MovementSpeed;
        }
        else
        {
            Rigidbody.velocity = Vector2.zero;
        }

        if (direction.x >= 0)
            SpriteRenderer.flipX = false;
        else
            SpriteRenderer.flipX = true;
    }

    void TickFireRate()
    {
        FireRateTimer -= Time.deltaTime;

        if (FireRateTimer <= 0)
        {
            Shoot();
            FireRateTimer = FireRate;
        }
    }

    void Shoot()
    {
        Vector3 pos = transform.position;
        Vector3 playerPos = Player.transform.position;

        Vector2 direction = playerPos - pos;
        direction.Normalize();

        for(int i = 0; i < ShotsPerVolley; i++)
        {
            SpawnProjectile(direction, i);
        }
    }

    void SpawnProjectile(Vector2 dir, int num)
    {
        float totalDegrees = SeperationDegrees * (ShotsPerVolley - 1);
        float angleOfFirstShot = -totalDegrees / 2;
        float angleOfThisShot = angleOfFirstShot + num * SeperationDegrees;

        float theta = Mathf.Deg2Rad * angleOfThisShot;

        float cs = Mathf.Cos(theta);
        float sn = Mathf.Sin(theta);
        Vector2 newDir;

        newDir.x = dir.x * cs - dir.y * sn;
        newDir.y = dir.x * sn + dir.y * cs;

        GameObject obj = Instantiate(Projectile);

        obj.transform.position = transform.position;
        Vector3 rot = transform.rotation.eulerAngles;
        obj.transform.rotation = Quaternion.Euler(rot);
        obj.GetComponent<Projectile>().Direction = newDir;
    }
}
