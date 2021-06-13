using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    [Tooltip("How many volleys fired per second")]
    public float FireRate;
    private float FireRateTimer;
    [Tooltip("How many shots in one volley")]
    public float ShotsPerVolley;
    [Tooltip("How many degrees between each shot in the volley")]
    public float SeperationDegrees;

    public GameObject Projectile;

    private GameObject Player;

    void Start()
    {
        FireRateTimer = FireRate;
        Player = GetComponent<Enemy>().Player;
    }

    void Update()
    {
        TickFireRate();
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
        float totalDegrees = SeperationDegrees * ShotsPerVolley;
        float currentDegrees = num * SeperationDegrees - totalDegrees / 4;

        float theta = Mathf.Deg2Rad * currentDegrees;

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
