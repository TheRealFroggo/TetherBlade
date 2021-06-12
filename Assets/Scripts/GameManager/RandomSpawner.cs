using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public List<Transform> SpawnPoints;
    public float LastSpawnTime;

    [Tooltip("Time between spawning new enemies, in seconds")]
    public float SpawnRate;

    [Tooltip("How quickly the spawn rate increases")]
    public float SpawnAccelerator;

    public GameObject Enemy;
    public GameObject Player;

    [SerializeField]
    GameManager GameManager;

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
        var now = Time.time;
        var elapsed = now - LastSpawnTime;
        if (elapsed > SpawnRate)
        {
            SpawnNewEnemy();
            LastSpawnTime = now;
            SpawnRate *= SpawnAccelerator;
        }
    }

    void SpawnNewEnemy()
    {
        GameObject newEnemy = Instantiate(Enemy);

        ChasePlayer chaser = newEnemy.GetComponent<ChasePlayer>();
        chaser.Player = Player;

        int whichSpawnPoint = Random.Range(0, 11);
        newEnemy.transform.position = SpawnPoints[whichSpawnPoint].position;
    }
}