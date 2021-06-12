using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public List<Transform> SpawnPoints;
    public float LastSpawnTime;
    public int NumEnemiesToSpawnAtOnce;

    [Tooltip("Time between spawning new enemies, in seconds")]
    public float SpawnRate;

    [Tooltip("How quickly the spawn rate increases")]
    public float SpawnAccelerator;

    public GameObject Enemy;
    public GameObject Player;

    [SerializeField]
    GameManager GameManager;

    void Start()
    {
        SpawnNewEnemies();
    }

    void Update()
    {
        UpdatePosition();
        CheckSpawnEnemy();
    }

    void UpdatePosition()
    {
        transform.position = Player.transform.position;
    }

    void CheckSpawnEnemy()
    {
        if (IsTimeToSpawn())
            SpawnNewEnemies();
    }

    bool IsTimeToSpawn()
    {
        var now = Time.time;
        var elapsed = now - LastSpawnTime;

        if (elapsed > SpawnRate)
        {
            LastSpawnTime = now;
            AdjustSpawnRate();
            SpawnRate *= SpawnAccelerator;
            return true;
        }
        return false;
    }

    void AdjustSpawnRate()
    {
        SpawnRate = Mathf.Clamp(SpawnAccelerator * SpawnRate, 1.0f, 5.0f);
    }

    void SpawnNewEnemies()
    {
        for (var i = 0; i < NumEnemiesToSpawnAtOnce; i++)
            SpawnNewEnemy();
    }

    void SpawnNewEnemy()
    {
        GameObject obj = Instantiate(Enemy);

        Enemy enemy = obj.GetComponent<Enemy>();
        enemy.GameManager = GameManager;
        enemy.Player = Player;

        int whichSpawnPoint = Random.Range(0, 11);
        obj.transform.position = SpawnPoints[whichSpawnPoint].position;
    }
}