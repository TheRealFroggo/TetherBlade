using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    public float FireRate;
    private float FireRateTimer;
    public float ShotsPerVolley;

    public GameObject Player;

    void Start()
    {
        FireRateTimer = FireRate;
    }

    void Update()
    {
        TickFireRate();
    }

    void TickFireRate()
    {
        FireRateTimer -= Time.deltaTime;

        if (FireRateTimer <= 0)
            Shoot();
    }

    void Shoot()
    {
        Vector3 pos = transform.position;
        Vector3 playerPos = Player.transform.position;

        Vector3 direction = playerPos - pos;
        direction.Normalize();
    }
}
