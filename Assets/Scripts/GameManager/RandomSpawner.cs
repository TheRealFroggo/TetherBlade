using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public List<Transform> SpawnPoints;
    public float LastSpawnTime;
    public int NumSpawnedEachTime;
    public int NumSpawnedAtStart;

    float SpawnInterval;

    [Tooltip("Initial time between spawning new enemies")]
    public float InitialSpawnInterval;

    [Tooltip("Minimum time between spawning new enemies")]
    public float MinSpawnInterval;

    [Tooltip("How quickly the spawn rate increases")]
    public float SpawnAccelerator;

    public List<GameObject> Enemies;
    public GameObject Player;

    [SerializeField]
    GameManager GameManager;

    void Start()
    {
        SpawnNewEnemies(NumSpawnedAtStart);
    }

    public void Reset()
    {
        SpawnInterval = InitialSpawnInterval;
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
            SpawnNewEnemies(NumSpawnedEachTime);
    }

    bool IsTimeToSpawn()
    {
        var now = Time.time;
        var elapsed = now - LastSpawnTime;

        if (elapsed > SpawnInterval)
        {
            LastSpawnTime = now;
            AdjustSpawnRate();
            return true;
        }
        return false;
    }

    void AdjustSpawnRate()
    {
        SpawnInterval = Mathf.Clamp(SpawnAccelerator * SpawnInterval, MinSpawnInterval, InitialSpawnInterval);
    }

    void SpawnNewEnemies(int numToSpawn)
    {
        for (var i = 0; i < numToSpawn; i++)
            SpawnNewEnemy();
    }

    void SpawnNewEnemy()
    {
        var percentile = Random.Range(0.0f, 100.0f);
        var whoToSpawn = percentile < 75.0 ? 0 : 1; // Boar 75% of time, Snake 25% of time
        GameObject obj = Instantiate(Enemies[whoToSpawn]);

        Enemy enemy = obj.GetComponent<Enemy>();
        enemy.GameManager = GameManager;
        enemy.Player = Player;

        int whichSpawnPoint = Random.Range(0, 11);
        obj.transform.position = SpawnPoints[whichSpawnPoint].position;
    }
}